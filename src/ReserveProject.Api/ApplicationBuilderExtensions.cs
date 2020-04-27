﻿using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using ReserveProject.Infrastructure.Database;
using ReserveProject.Infrastructure.Database.Configurations.Dapper;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Http;

namespace ReserveProject.Api
{
    public static class ApplicationBuilderExtensions
    {
        public static IApplicationBuilder AddSwagger(this IApplicationBuilder applicationBuilder)
        {
            applicationBuilder.UseSwagger();
            applicationBuilder.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");
                c.RoutePrefix = string.Empty;
            });
            return applicationBuilder;
        }

        public static IApplicationBuilder AllowCors(this IApplicationBuilder applicationBuilder)
        {
            applicationBuilder.UseCors(opt =>
            {
                opt.AllowAnyHeader()
                    .AllowAnyMethod()
                    .AllowAnyOrigin()
                    .WithExposedHeaders();
            });
            return applicationBuilder;
        }

        public static IApplicationBuilder InitializeDatabase(this IApplicationBuilder applicationBuilder)
        {
            using (var serviceScope = applicationBuilder.ApplicationServices.GetRequiredService<IServiceScopeFactory>()
                .CreateScope())
            {
                serviceScope.ServiceProvider.GetService<PrimeDbContext>().Database.Migrate();
            }

            DapperNamingMapperExtensions.DefineDapperNameMapping();

            return applicationBuilder;
        }
    }
}