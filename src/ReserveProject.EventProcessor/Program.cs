using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using ReserveProject.Application.Services;
using ReserveProject.DI;
using System;
using System.IO;
using System.Threading;
using System.Threading.Tasks;

namespace ReserveProject.EventProcessor
{
    class Program
    {
        static void Main(string[] args)
        {
            MainAsync().GetAwaiter().GetResult();
        }

        public static async Task MainAsync()
        {
            var config = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", true)
                .AddEnvironmentVariables()
                .Build();
            using (var serviceProvider = new PrimeDependencyResolver(config).Resolve()
                .AsynchronousEventDispatching()
                .BuildServiceProvider())
            {
                while (true)
                {
                    var eventProcessor = serviceProvider.GetService<AsynchronousEventProcessor>();
                    await eventProcessor.Process();
                    Thread.Sleep(2000);
                }
            }
        }
    }
}
