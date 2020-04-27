using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using System.IO;
using System.Net;

namespace ReserveProject.Api
{
    public class Program
    {
        public static void Main(string[] args)
        {
            BuildWebHost(args).Run();
        }

        public static IWebHostBuilder CreateWebHostBuilder(string[] args)
        {
            return WebHost.CreateDefaultBuilder(args)
                .UseStartup<Startup>();
        }

        public static IWebHost BuildWebHost(string[] args) => WebHost.CreateDefaultBuilder(args)
                                                                    .UseKestrel(options =>
                                                                    {
                                                                        options.ListenAnyIP(5200, listenOptions =>
                                                                        {
                                                                            listenOptions.UseHttps("selfsignedcert.pfx", "selfsignedcert");
                                                                        });
                                                                    })
                                                                    .CaptureStartupErrors(true)
                                                                    .UseContentRoot(Directory.GetCurrentDirectory())
                                                                    .UseIISIntegration()
                                                                    .UseStartup<Startup>()
                                                                    .Build();
    }
}