using System;

namespace sanity_metrics
{
    public class IpAddressHelper
    {
        public static string RemovePort(string ip)
        {
            if (string.IsNullOrWhiteSpace(ip))
            {
                return string.Empty;
            }

            var colonIndex = ip.IndexOf(":");

            if (colonIndex > 0)
            {
                return ip.Substring(0, colonIndex).Trim();
            }
            return ip.Trim();
        }
    }
}
