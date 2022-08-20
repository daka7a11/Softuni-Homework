using Microsoft.AspNetCore.Mvc.Filters;

namespace Demo.Filters
{
    public class MyExceptionFilterAttribute : IExceptionFilter
    {
        public void OnException(ExceptionContext context)
        {
            context.HttpContext.Response.Headers.Add("XX-Exception: ", context.Exception.Message);
            context.HttpContext.Response.Cookies.Append("XX-Exception", context.Exception.Message);
        }
    }
}
