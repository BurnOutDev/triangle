using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace ReserveProject.Api
{
    public class Startup
    {
        private readonly IConfiguration _configuration;


        public Startup(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services
                .AddAuthorization(_configuration)
                .AddSwagger()
                .AddDi(_configuration)
                .AddMvc(option => option.EnableEndpointRouting = false)
                .AddNewtonsoftJson()
                .SetCompatibilityVersion(CompatibilityVersion.Version_3_0);
        }

        public void Configure(IApplicationBuilder app)
        {
            app
                .AddSwagger()
                .AllowCors()
                .InitializeDatabase()
                .UseHttpsRedirection()
                .UseAuthentication()
                .UseExceptionHandler(
               ops =>
               {
                   ops.Run(
                   async context =>
                   {
                       var ex = context.Features.Get<IExceptionHandlerFeature>();
                       await context.Response.WriteAsync(ex.Error.ToString()).ConfigureAwait(false);
                   });
               })
              .UseMvc();
        }
    }
}