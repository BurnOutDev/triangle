using System;
using System.Linq;
using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;

namespace ReserveProject.Infrastructure.Repositories.Abstractions
{
    public interface IRepository<T> where T : class
    {
        T Find(Guid uId, bool onlyActive = true);

        IQueryable<T> Query(Expression<Func<T, bool>> expression = null, bool onlyActives = true);

        void Store(T document);

        void WithDbContext(DbContext dbContext);
    }
}