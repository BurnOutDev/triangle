using System;
using System.Linq;
using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using ReserveProject.Domain.Shared.Abstract;
using ReserveProject.Infrastructure.Database;
using ReserveProject.Infrastructure.Database.Extensions;

namespace ReserveProject.Application.Infrastructure
{
    public class RepositoryBase
    {
        private readonly PrimeDbContext _db;

        public RepositoryBase(PrimeDbContext db)
        {
            _db = db;
        }
        public T Entity<T>(Guid uId, params Expression<Func<T, dynamic>>[] includeExpression) where T : BaseEntity
        {
            var dbset = _db.Set<T>().GetActiveEntities().ByUId(uId);
            foreach (var item in includeExpression)
            {
                dbset = dbset.Include(item);
            }
            return dbset.SingleOrDefault(x => x.UId == uId);
        }

        public int EntityId<T>(Guid uId) where T : BaseEntity
        {
            var dbset = _db.Set<T>().GetActiveEntities().ByUId(uId);
            var id = dbset.Select(x => x.Id).SingleOrDefault();
            return id;
        }

        public int Count<T>() where T : BaseEntity
        {
            return _db.Set<T>().GetActiveEntities().Count();
        }
    }
}