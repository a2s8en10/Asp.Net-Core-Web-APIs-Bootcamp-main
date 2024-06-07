using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;
using System;

namespace ConsoleToWebAPIproject
{
    internal class Program
    {
        static void Main(string[] args)
        {
            CreatehostBuilder().Build().Run();
        }
        public static IHostBuilder CreatehostBuilder()
        {
            return Host.CreateDefaultBuilder()
        
            .ConfigureWebHostDefaults(WebHost =>
            {
                WebHost.UseStartup<Startup>();
            });
        }
    }
}
