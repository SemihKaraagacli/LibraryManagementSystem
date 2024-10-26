using LibraryManagementSystem.Services.Book.ViewModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Net;

namespace LibraryManagementSystem_EFCore_.Filters
{
    public class ExceptionFilter : IExceptionFilter
    {
        public void OnException(ExceptionContext context)
        {
            var errorDetails = new ErrorViewModel
            {
                Message = "Bir hata oluştu. Lütfen daha sonra tekrar deneyin.",
                ExceptionMessage = context.Exception.Message,
                StackTrace = context.Exception.StackTrace
            };
            context.Result = new RedirectToActionResult("Error", "Home", errorDetails);
            context.ExceptionHandled = true;
        }
    }
}
