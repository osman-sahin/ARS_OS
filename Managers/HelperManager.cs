using Microsoft.Extensions.Primitives;
using System.Text.RegularExpressions;

namespace ARS_OS.Managers
{
    public interface IHelperManager
    {
        string GetRequestIp(bool tryUseXForwardHeader = true);
    }
    public class HelperManager : IHelperManager
    {
        private readonly IHttpContextAccessor _accessor;

        public HelperManager(IHttpContextAccessor accessor)
        {
            _accessor = accessor;
        }

        public string GetRequestIp(bool tryUseXForwardHeader = true)
        {
            string? ip = string.Empty;
            if (tryUseXForwardHeader)
            {
                var v = GetHeaderValueAs<string>("X-Original-Forwarded-For");
                if (!string.IsNullOrEmpty(v))
                    ip = v.TrimEnd(',')
                        .Split(',')
                        .AsEnumerable<string>()
                        .Select(s => s.Trim())
                        .ToList().FirstOrDefault();
            }

            if (string.IsNullOrWhiteSpace(ip) && _accessor.HttpContext?.Connection?.RemoteIpAddress != null)
                ip = _accessor.HttpContext.Connection.RemoteIpAddress.ToString();

            if (string.IsNullOrWhiteSpace(ip))
                ip = GetHeaderValueAs<string>("REMOTE_ADDR");

            if (string.IsNullOrWhiteSpace(ip))
                throw new Exception("Unable to determine caller's IP.");
            return ip;
        }

        private T? GetHeaderValueAs<T>(string headerName)
        {
            StringValues values = default;

            if (!(_accessor.HttpContext?.Request?.Headers?.TryGetValue(headerName, out values) ?? false))
                return default(T);
            var rawValues = values.ToString();   // writes out as Csv when there are multiple.

            if (!string.IsNullOrWhiteSpace(rawValues))
                return (T)Convert.ChangeType(values.ToString(), typeof(T));
            return default(T);
        }
    }

}
