using System.Net.NetworkInformation;
using System.Net;
using Microsoft.Azure.Functions.Worker.Http;
using sanity_metrics;

namespace SanityMetrics
{
    public class SearchEngineChecker
    {
        public static SearchEngineCheckResult IsRequestFromSearchEngineCrawler(HttpRequestData req)
        {
            if (req.Headers.TryGetValues("X-Forwarded-For", out IEnumerable<string> ipHeaderVals))
            {
                var ipString = IpAddressHelper.RemovePort(ipHeaderVals.FirstOrDefault());

                if (DuckDuckGoCrawlerIpAddresses.Contains(ipString))
                {
                    return new SearchEngineCheckResult(true, "DuckDuckGo");
                }

                var ipParts = ipString.Split(".");
                var ip = new IPAddress(ipParts.Select(e => byte.Parse(e)).ToArray());

                if (GoogleCrawlerIpAddresses.Any(e => e.IsInRange(ip)))
                {
                    return new SearchEngineCheckResult(true, "Google");
                }
            }

            return new SearchEngineCheckResult(false);
        }

        private static HashSet<string> DuckDuckGoCrawlerIpAddresses = new HashSet<string>
        {
          "20.191.45.212",
          "40.88.21.235",
          "40.76.173.151",
          "40.76.163.7",
          "20.185.79.47",
          "52.142.26.175",
          "20.185.79.15",
          "52.142.24.149",
          "40.76.162.208",
          "40.76.163.23",
          "40.76.162.191",
          "40.76.162.247"
        };

        private static HashSet<IPAddressRange> GoogleCrawlerIpAddresses = new HashSet<IPAddressRange>
        {
          new IPAddressRange(new IPAddress(new byte[4] { 66, 249, 64, 0 }), new IPAddress(new byte[4] { 66, 249, 64, 255 })),
          new IPAddressRange(new IPAddress(new byte[4] { 66, 249, 65, 0 }), new IPAddress(new byte[4] { 66, 249, 65, 255 })),
          new IPAddressRange(new IPAddress(new byte[4] { 66, 249, 66, 0 }), new IPAddress(new byte[4] { 66, 249, 66, 255 })),
          new IPAddressRange(new IPAddress(new byte[4] { 66, 249, 66, 0 }), new IPAddress(new byte[4] { 66, 249, 66, 255 })),
          new IPAddressRange(new IPAddress(new byte[4] { 66, 249, 68, 0 }), new IPAddress(new byte[4] { 66, 249, 68, 255 })),
          new IPAddressRange(new IPAddress(new byte[4] { 66, 249, 69, 0 }), new IPAddress(new byte[4] { 66, 249, 69, 255 })),
          new IPAddressRange(new IPAddress(new byte[4] { 66, 249, 70, 0 }), new IPAddress(new byte[4] { 66, 249, 70, 255 })),
          new IPAddressRange(new IPAddress(new byte[4] { 66, 249, 71, 0 }), new IPAddress(new byte[4] { 66, 249, 71, 255 })),
          new IPAddressRange(new IPAddress(new byte[4] { 66, 249, 72, 0 }), new IPAddress(new byte[4] { 66, 249, 72, 255 })),
          new IPAddressRange(new IPAddress(new byte[4] { 66, 249, 73, 0 }), new IPAddress(new byte[4] { 66, 249, 73, 255 })),
          new IPAddressRange(new IPAddress(new byte[4] { 66, 249, 74, 0 }), new IPAddress(new byte[4] { 66, 249, 74, 255 })),
          new IPAddressRange(new IPAddress(new byte[4] { 66, 249, 75, 0 }), new IPAddress(new byte[4] { 66, 249, 75, 255 })),
          new IPAddressRange(new IPAddress(new byte[4] { 66, 249, 76, 0 }), new IPAddress(new byte[4] { 66, 249, 76, 255 })),
          new IPAddressRange(new IPAddress(new byte[4] { 66, 249, 77, 0 }), new IPAddress(new byte[4] { 66, 249, 77, 255 })),
          new IPAddressRange(new IPAddress(new byte[4] { 66, 249, 79, 0 }), new IPAddress(new byte[4] { 66, 249, 79, 255 })),
        };
    }

    public class SearchEngineCheckResult
    {
        public SearchEngineCheckResult(bool isFromSearchEngine, string searchEngine = "")
        {
            IsFromSearchEngine = isFromSearchEngine;
            SearchEngine = searchEngine;
        }
        public bool IsFromSearchEngine { get; set; }
        public string SearchEngine { get; set; }
    }
}
