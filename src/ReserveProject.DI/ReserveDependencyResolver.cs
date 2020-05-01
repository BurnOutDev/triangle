using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using ReserveProject.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Debug;
using Microsoft.AspNetCore.Http;
using ReserveProject.Application;

namespace ReserveProject.DI
{
    public class ReserveDependencyResolver
    {
        private IServiceCollection _serviceCollection;

        public ReserveDependencyResolver(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        private IConfiguration Configuration { get; }

        public ReserveDependencyResolver Resolve(IServiceCollection services = null)
        {
            if (services == null)
            {
                services = new ServiceCollection();
            }

            _serviceCollection = services;

            string connectionString = Configuration.GetConnectionString("ReserveDbContext");
            services.AddSingleton(Configuration);
            services.AddDbContext<ReserveDbContext>(options => options.UseLazyLoadingProxies()
                                                                      .UseSqlServer(connectionString, x => x.UseNetTopologySuite())
                                                                      .UseLoggerFactory(new LoggerFactory(new[] { new DebugLoggerProvider() })));

            services.AddTransient<IHttpContextAccessor, HttpContextAccessor>();

            services.AddScoped<ICuisineService, CuisineService>();

            return this;
        }
    }
}
