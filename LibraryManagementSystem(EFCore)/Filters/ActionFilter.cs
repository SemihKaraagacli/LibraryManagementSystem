using Microsoft.AspNetCore.Mvc.Filters;
using System.Diagnostics;

namespace LibraryManagementSystem_EFCore_.Filters
{
    public class ActionFilter : Attribute, IActionFilter
    {
        private readonly ILogger<ActionFilter> _logger;
        private Stopwatch _stopwatch;

        public ActionFilter(ILogger<ActionFilter> logger)
        {
            _logger = logger;
        }

        public void OnActionExecuted(ActionExecutedContext context)
        {
            _stopwatch.Stop();
            var actionName = context.ActionDescriptor.DisplayName;
            _logger.LogInformation($"[{actionName}] işlemi tamamlandı. Süre: {_stopwatch.ElapsedMilliseconds} ms");
        }

        public void OnActionExecuting(ActionExecutingContext context)
        {
            _stopwatch = Stopwatch.StartNew();
            var actionName = context.ActionDescriptor.DisplayName;
            _logger.LogInformation($"[{actionName}] işlemine başlandı.");
        }
    }
}
