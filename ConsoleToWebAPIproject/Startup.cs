using ConsoleToWebAPIproject.Controller;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System.Reflection.Metadata;

namespace ConsoleToWebAPIproject
{
    public class Startup
    {
        public void configureservices(IServiceCollection services)
        {
            services.AddControllers();
            services.AddTransient<CustomMiddleware>();
        }
        public void configure (IApplicationBuilder app , IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            //app.Run(async context =>
            //{
            //    await context.Response.WriteAsync("hello form RUN");
            //});

            // use and next middleware 
            //app.Use(async (context, next) =>
            //{
            //    await context.Response.WriteAsync("hello form use 1-1 and next \n");
            //    await next();
            //    await context.Response.WriteAsync("hello form use 1-2 and next \n");
            //});

            //app.Use(async (context, next) =>
            //{
            //    await context.Response.WriteAsync("hello form use 2-1 and next \n");
            //    await next();
            //    await context.Response.WriteAsync("hello form use 2-2 and next \n");
            //});

            //app.UseMiddleware<CustomMiddleware>();

            // map middleware (URL/anurag)
            //app.Map("/anurag",code);

            // run middleware 
            //app.Run(async context =>
            //{
            //    await context.Response.WriteAsync("hello form RUN 2 \n");
            //});

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

        // map middleware
        private void code(IApplicationBuilder app)
        {
            app.Use(async (context, next) =>
            {
                await context.Response.WriteAsync("hello anurag sahu \n");
            });
        }
    }
}
