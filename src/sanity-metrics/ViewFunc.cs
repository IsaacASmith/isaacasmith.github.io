using System.Collections.Generic;
using System.Diagnostics;
using System.Net;
using System.Security.Cryptography;
using System.Text;
using System.Text.Json;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Azure.Functions.Worker.Http;
using Microsoft.Extensions.Logging;

namespace SanityMetrics
{
  public class ViewFunc
  {
    private readonly ILogger _logger;

    public ViewFunc(ILoggerFactory loggerFactory)
    {
      _logger = loggerFactory.CreateLogger<ViewFunc>();
    }

    [Function("view")]
    public async Task<HttpResponseData> Run([HttpTrigger(AuthorizationLevel.Anonymous, "post")] HttpRequestData req)
    {
      try
      {
        var viewData = await req.ReadFromJsonAsync<ViewData>();
        string updatedClient = viewData.Client.ToString();

        string screenSize = getScreenSize(viewData.ScreenWidth);

        var hasReqIp = req.Headers.TryGetValues("X-Forwarded-For", out IEnumerable<string> ipHeaderVals);
        if (hasReqIp)
        {
          updatedClient = computeSHA256Hash($"{viewData.Client}|{ipHeaderVals.FirstOrDefault()}");
        }

        Activity.Current?.AddBaggage("viewData", JsonSerializer.Serialize(viewData, new JsonSerializerOptions
        {
          PropertyNamingPolicy = JsonNamingPolicy.CamelCase
        }));

        using var scope = _logger.BeginScope(new
        {
          viewData.Path,
          viewData.PageTitle,
          viewData.Referrer,
          Client = updatedClient,
          UTMData = new {
            viewData.UTMData?.Medium,
            viewData.UTMData?.Source,
            viewData.UTMData?.Campaign,
            viewData.UTMData?.Content,
          }
        });
        _logger.LogInformation("pageView");
        scope.Dispose();

        var response = req.CreateResponse(HttpStatusCode.OK);
        return response;
      }
      catch (Exception ex)
      {
        _logger.LogError(ex, "Error logging view.");
        var response = req.CreateResponse(HttpStatusCode.OK);
        return response;
      }
    }

    private string getScreenSize(int screenWidth)
    {
      if (screenWidth < 500)
        return "Mobile";
      if (screenWidth < 1000)
        return "Tablet";
      return "Desktop";
    }

    private string computeSHA256Hash(string val)
    {
      var hashBytes = SHA256.HashData(Encoding.ASCII.GetBytes(val));
      return BitConverter.ToString(hashBytes).Replace("-", "");
    }
  }

  public class ViewData
  {
    public string Path { get; set; }
    public string PageTitle { get; set; }
    public string Referrer { get; set; }
    public int Client { get; set; }
    public int ScreenWidth { get; set; }

    public void LowerCaseAllProps()
    {
      Path = Path?.ToLower();
      PageTitle = PageTitle?.ToLower();
      Referrer = Referrer?.ToLower();
    }

    public UTMData UTMData { get; set; }
  }

  public class UTMData
  {
    public string Medium { get; set; }
    public string Source { get; set; }
    public string Campaign { get; set; }
    public string Content { get; set; }
  }
}
