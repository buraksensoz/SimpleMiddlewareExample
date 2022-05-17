using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;

namespace MiddlewareSampleProject.App.Middleware
{
    public class SampleMiddleware
    {
        private readonly RequestDelegate _next;

        public SampleMiddleware(RequestDelegate next)
        {
            _next = next;
        }


        public async Task Invoke(HttpContext context) {
            var cookieValue = context.Request.Cookies["MiddlewareCookie"];
            var requestCount = 0;
            try //if MiddlewareCookie isn't integer value
            {
                requestCount = string.IsNullOrEmpty(cookieValue) ? 0 : int.Parse(cookieValue);
            }
            catch { }
            requestCount++;

            context.Response.Cookies.Append("MiddlewareCookie", requestCount.ToString()) ;

            await _next(context); //Go to Next Middleware
        }
    }
}
