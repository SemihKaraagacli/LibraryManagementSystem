using System.Net;

namespace LibraryManagementSystem_EFCore_.MiddleWare
{
    public class IpBlockingMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly HashSet<IPAddress> _blockedIps;

        public IpBlockingMiddleware(RequestDelegate next, IEnumerable<IPAddress> blockedIps)
        {
            _next = next;
            _blockedIps = new HashSet<IPAddress>(blockedIps);
        }

        public async Task Invoke(HttpContext context)
        {
            var remoteIp = context.Connection.RemoteIpAddress;

            if (_blockedIps.Contains(remoteIp))
            {
                context.Response.StatusCode = StatusCodes.Status403Forbidden;
                await context.Response.WriteAsync("IP adresiniz engellenmiştir.");
                return;
            }

            await _next(context);
        }
    }
}
