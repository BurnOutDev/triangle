﻿using IdentityServer4.AccessTokenValidation;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authentication.OpenIdConnect;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using ReserveProject.DI;
using ReserveProject.Shared;
using System.Text;

namespace ReserveProject.Api
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddSwagger(this IServiceCollection serviceCollection)
        {
            serviceCollection.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo
                {
                    Title = "My API",
                    Version = "v1"
                });
                c.CustomSchemaIds(x => x.FullName);
            });
            return serviceCollection;
        }

        public static IServiceCollection AddDi(this IServiceCollection serviceCollection, IConfiguration configuration)
        {
            new ReserveDependencyResolver(configuration).Resolve(serviceCollection);
            return serviceCollection;
        }

        public static IServiceCollection AddAuthorization(this IServiceCollection serviceCollection, IConfiguration configuration)
        {
            var authConfiguration = configuration.GetSection(ConfigurationItem.Authorization);

            var privateKey = authConfiguration.GetValue<string>(ConfigurationItem.PrivateKey);
            var issuerSignInKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(privateKey));

            var authoriy = authConfiguration.GetValue<string>(ConfigurationItem.Authority);

            var audience = authConfiguration.GetValue<string>(ConfigurationItem.Audience);

            serviceCollection
                .AddAuthentication(IdentityServerAuthenticationDefaults.AuthenticationScheme)
                .AddIdentityServerAuthentication(options =>
                {
                    options.Authority = authoriy;
                    options.ApiName = "reservationapi";
                    options.RequireHttpsMetadata = false;
                    options.JwtBearerEvents.OnAuthenticationFailed = async (error) =>
                    {
                        string er = error.Result.Ticket.AuthenticationScheme;
                    };
                });

            return serviceCollection;
        }
    }
}
