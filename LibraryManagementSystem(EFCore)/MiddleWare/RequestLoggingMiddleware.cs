using System.Diagnostics;

namespace LibraryManagementSystem_EFCore_.MiddleWare
{
    public class RequestLoggingMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<RequestLoggingMiddleware> _logger;

        public RequestLoggingMiddleware(RequestDelegate next, ILogger<RequestLoggingMiddleware> logger)
        {
            _next = next;
            _logger = logger;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            var stopWatch = Stopwatch.StartNew();

            // İsteği işleme al
            await _next(context);

            stopWatch.Stop();

            // Loglama
            var method = context.Request.Method;
            var url = context.Request.Path;
            var elapsedMilliseconds = stopWatch.ElapsedMilliseconds;

            _logger.LogInformation($"Request: {method} {url} responded in {elapsedMilliseconds} ms");
        }
    }
}
