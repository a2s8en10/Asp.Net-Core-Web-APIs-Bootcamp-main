using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;

namespace ConsoleToWebAPIproject
{
    public class CustomMiddleware : IMiddleware
    {
        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
       
        {
            await context.Response.WriteAsync("hello CustomMiddleware from file 1 \n");

            await next(context);

            await context.Response.WriteAsync("hello CustomMiddleware from file 2 \n");

        }
    
    }
}
