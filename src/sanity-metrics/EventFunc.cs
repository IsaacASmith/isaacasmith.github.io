using System.Net;
using System.Security.Cryptography;
using System.Text;
using System.Text.Json;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Azure.Functions.Worker.Http;
using Microsoft.Extensions.Logging;

namespace SanityMetrics
{
    public class EventFunc
    {
        private readonly ILogger _logger;

        public EventFunc(ILoggerFactory loggerFactory)
        {
            _logger = loggerFactory.CreateLogger<EventFunc>();
        }

        [Function("event")]
        public async Task<HttpResponseData> Run([HttpTrigger(AuthorizationLevel.Anonymous, "post")] HttpRequestData req)
        {
            try
            {
                var eventData = await req.ReadFromJsonAsync<EventData>();
                string updatedClient = eventData.Client.ToString();

                if (req.Headers.TryGetValues("X-Forwarded-For", out IEnumerable<string> ipHeaderVals))
                {
                    updatedClient = computeSHA256Hash($"{eventData.Client}|{ipHeaderVals.FirstOrDefault()}");
                }

                if (eventData.Data != null)
                {
                    _logger.LogInformation(new EventId(10002, "userEvent"), JsonSerializer.Serialize(new
                    {
                        eventData.Page,
                        Client = updatedClient,
                        eventData.Data
                    }));
                }

                var response = req.CreateResponse(HttpStatusCode.OK);
                return response;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error logging Event.");
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

    public class EventData
    {
        public string Page { get; set; }
        public int Client { get; set; }
        public object Data { get; set; }
    }
}
