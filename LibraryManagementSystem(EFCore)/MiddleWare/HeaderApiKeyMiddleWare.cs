namespace LibraryManagementSystem_EFCore_.MiddleWare
{
    public class HeaderApiKeyMiddleWare
    {
        private readonly RequestDelegate _next;

        public HeaderApiKeyMiddleWare(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context)
        {

            if (!context.Request.Headers.TryGetValue("API-Key", out var apiKey) || string.IsNullOrEmpty(apiKey))
            {
                context.Response.StatusCode = StatusCodes.Status401Unauthorized;
                await context.Response.WriteAsync("Unauthorized: API-Key required");
                return;
            }

            await _next(context);
        }
    }
}
