using System;
using System.Linq;
using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using ReserveProject.Infrastructure.Repositories.Abstractions;
using ReserveProject.Domain.Shared.Abstract;
using ReserveProject.Infrastructure.Database.Extensions;

namespace ReserveProject.Infrastructure.Repositories.Implementations
{
    public class EfRepository<T> : IRepository<T> where T : BaseEntity
    {
        private DbContext _db;

        public EfRepository(DbContext db)
        {
            _db = db;
        }

        public virtual T Find(Guid uId, bool onlyActive = true)
        {
            return onlyActive
                ? _db.Set<T>().GetActiveEntities().SingleOrDefault(x => x.UId == uId)
                : _db.Set<T>().GetActiveEntities().SingleOrDefault(x => x.UId == uId);
        }

        public virtual IQueryable<T> Query(
            Expression<Func<T, bool>> expression = null,
            bool onlyActives = true)
        {
            var baseQuery = onlyActives ? _db.Set<T>().GetActiveEntities() : _db.Set<T>();

            if (expression == null)
                return baseQuery.AsQueryable();
            return baseQuery.Where(expression).AsQueryable();
        }

        public virtual void Store(T document)
        {
            _db.Set<T>().Add(document);
        }

        public void WithDbContext(DbContext dbContext)
        {
            _db = dbContext;
        }
    }
}