using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace ReserveProject.Api
{
    public class Startup
    {
        public IConfiguration Configuration { get; }

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services
               .AddAuthorization(Configuration)
               .AddSwagger()
               .AddDi(Configuration)
               .AddMvc(option => option.EnableEndpointRouting = false)
               .AddNewtonsoftJson()
               .SetCompatibilityVersion(CompatibilityVersion.Version_3_0);
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            //if (env.IsDevelopment())
            //{
            //    app.UseDeveloperExceptionPage();
            //}

            //app.UseHttpsRedirection();

            //app.UseRouting();

            //app.UseAuthorization();

            //app.UseEndpoints(endpoints =>
            //{
            //    endpoints.MapControllers();
            //});

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
