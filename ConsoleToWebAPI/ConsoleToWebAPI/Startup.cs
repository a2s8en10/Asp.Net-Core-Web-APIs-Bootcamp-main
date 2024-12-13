using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;

namespace ConsoleToWebAPI
{
    public class Startup
    {
        public void configureservices (IServiceCollection services)
        {
            services.AddControllers ();
            services.AddTransient<CustomMiddleware1>();
        }
        public void configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            //app.Use(async (context, next) =>
            //{
            //    await context.Response.WriteAsync("hello from use-1 1 \n" );

            //    await next();

            //    await context.Response.WriteAsync("hello from use-1 2 \n");
            //});

            //app.UseMiddleware<CustomMiddleware1>();      // create the new middle ware 

            //app.Map("/Anurag", Coustomcode);

            //app.Use(async (context, next) =>
            //{
            //    await context.Response.WriteAsync("hello from use-2 1 \n");
            //    await next();
            //    await context.Response.WriteAsync("hello from use-2 2 \n");

            //});

            //app.Run(async context =>
            //{
            //    await context.Response.WriteAsync("Hello from Run \n");
            //});

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();
            app.UseEndpoints(endpoint =>
            {
                endpoint.MapControllers();
            });
        }

        private void Coustomcode(IApplicationBuilder app)
        {
            app.Use(async (context, next) =>
            {
                await context.Response.WriteAsync("Hello from Anurag \n");
                
            });

        }
    }
}
