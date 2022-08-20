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
                var response = req.CreateResponse(HttpStatusCode.OK);

                var searchEngineCrawlerCheckResult = SearchEngineChecker.IsRequestFromSearchEngineCrawler(req);
                if (searchEngineCrawlerCheckResult.IsFromSearchEngine)
                {
                    _logger.LogInformation(new EventId(10003, "searchEngineCrawler"), JsonSerializer.Serialize(new
                    {
                        SearchEngine = searchEngineCrawlerCheckResult.SearchEngine
                    }));
                    return response;
                }

                var viewData = await req.ReadFromJsonAsync<ViewData>();
                viewData.LowerCaseAllProps();

                string updatedClient = viewData.Client.ToString();

                string screenSize = getScreenSize(viewData.ScreenWidth);

                if (req.Headers.TryGetValues("X-Forwarded-For", out IEnumerable<string> ipHeaderVals))
                {
                    updatedClient = computeSHA256Hash($"{viewData.Client}|{ipHeaderVals.FirstOrDefault()}");
                }

                _logger.LogInformation(new EventId(10001, "pageView"), JsonSerializer.Serialize(new
                {
                    viewData.Path,
                    viewData.Referrer,
                    viewData.IsInternalNav,
                    viewData.InternalReferrer,
                    ScreenSize = screenSize,
                    Client = updatedClient,
                    UTMData = new
                    {
                        viewData.UTMData?.Medium,
                        viewData.UTMData?.Source,
                        viewData.UTMData?.Campaign,
                        viewData.UTMData?.Content,
                    }
                }));

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
        public bool IsInternalNav { get; set; }
        public string InternalReferrer { get; set; }
        public int Client { get; set; }
        public int ScreenWidth { get; set; }

        public void LowerCaseAllProps()
        {
            Path = Path?.ToLower();
            PageTitle = PageTitle?.ToLower();
            Referrer = Referrer?.ToLower();
            InternalReferrer = InternalReferrer?.ToLower();
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
