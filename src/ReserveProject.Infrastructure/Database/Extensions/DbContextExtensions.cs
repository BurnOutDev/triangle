using System;
using System.Linq;
using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using ReserveProject.Domain.Enums;
using ReserveProject.Domain.Shared.Abstract;

namespace ReserveProject.Infrastructure.Database.Extensions
{
    public static class DbContextExtensions
    {
        public static IQueryable<T> ByUId<T>(this IQueryable<T> source, Guid uId) where T : IBaseEntity
        {
            return source.Where(entity => entity.UId == uId);
        }

        public static IQueryable<T> GetActiveEntities<T>(this IQueryable<T> source) where T : IBaseEntity
        {
            return source.Where(entity => entity.EntityStatus == EntityStatus.Active);
        }

        public static IQueryable<T> LocalOrDatabase<T>(this DbContext context, Expression<Func<T, bool>> expression)
            where T : class
        {
            var localResults = context.Set<T>().Local.Where(expression.Compile());

            var enumerable = localResults.ToList();
            if (enumerable.Any()) return enumerable.AsQueryable();

            var databaseResults = context.Set<T>().Where(expression);

            return databaseResults;
        }
    }
}