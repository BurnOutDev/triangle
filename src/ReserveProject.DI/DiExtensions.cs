using Microsoft.Extensions.DependencyInjection;
using System;
using System.Linq;

namespace ReserveProject.DI
{
    public static class DiExtensions
    {
      
        public static IServiceCollection Replace<TService>(
                            this IServiceCollection services,
                            Func<IServiceProvider, TService> instance,
                            ServiceLifetime lifetime)
                            where TService : class
        {
            var descriptorToRemove = services.FirstOrDefault(d => d.ServiceType == typeof(TService));

            services.Remove(descriptorToRemove);

            var descriptorToAdd = new ServiceDescriptor(typeof(TService), instance, lifetime);

            services.Add(descriptorToAdd);

            return services;
        }
    }
}