using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;

namespace ConsoleToWebAPIproject
{
    public class Startup
    {
        public void configureservices(IServiceCollection services)
        {
            services.AddControllers();
        }
        public void configure (IApplicationBuilder app , IWebHostEnvironment env)
        {
            app.UseRouting();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers(); 
            });

                //app.UseEndpoints(endpoints =>
                //{
                //    endpoints.MapGet("/", async context =>
                //    {
                //        await context.Response.WriteAsync("hello from new web api app");
                //    });
                //});
            }
    }
}
