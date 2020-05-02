using System;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using ReserveProject.Shared.ApplicationInfrastructure;

namespace ReserveProject.DI
{
    public class ApplicationContextFactory
    {
        public static ApplicationContext Create(IServiceProvider ctx)
        {
            var httpContext = ctx.GetService<IHttpContextAccessor>().HttpContext;
            var remoteIpAddress = httpContext?.Connection?.RemoteIpAddress?.ToString();
            return new ApplicationContext(remoteIpAddress);
        }
    }
}