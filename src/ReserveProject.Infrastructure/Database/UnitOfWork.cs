using System.Linq;
using System.Threading.Tasks;
using ReserveProject.Shared.ApplicationInfrastructure;
using MediatR;
using Microsoft.EntityFrameworkCore;
using ReserveProject.Domain.Shared.Abstract;
using ReserveProject.Infrastructure.EventDispatching;
using ReserveProject.Shared.Date;
using ReserveProject.Shared.DomainInfrastructure;
using ReserveProject.Shared.Logging;
using ReserveProject.Shared.Serialization;

namespace ReserveProject.Infrastructure.Database
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationContext _applicationContext;
        private readonly PrimeDbContext _dbContext;
        private readonly IMediator _mediator;
        private readonly TransactionalDomainEventDispatcher _transactionalDomainEventDispatcher;

        public UnitOfWork(
            PrimeDbContext dbContext,
            ApplicationContext applicationContext,
            IMediator mediator,
            TransactionalDomainEventDispatcher transactionalDomainEventDispatcher
        )
        {
            _dbContext = dbContext;
            _applicationContext = applicationContext;
            _mediator = mediator;
            _transactionalDomainEventDispatcher = transactionalDomainEventDispatcher;
        }

        public async Task Save()
        {
            var modifiedEntries = _dbContext.ChangeTracker.Entries<IHasDomainEvents>().ToList();
            foreach (var entry in modifiedEntries)
            {
                var events = entry.Entity.UncommittedChanges();

                if (events.Any())
                {
                    await _transactionalDomainEventDispatcher.Dispatch(events, _mediator);
                    foreach (var evnt in events)
                    {
                        var serializedEvent = Serializer.Serialize(evnt);
                        _dbContext.Set<Event>().Add(new Event(
                            evnt.EventType,
                            serializedEvent,
                            evnt.UId,
                            _applicationContext.ClientIpAddress));
                    }

                    entry.Entity.MarkChangesAsCommitted();
                }
            }
            DateTraction(_dbContext);
            await _dbContext.SaveChangesAsync();
        }
        private void DateTraction(PrimeDbContext primeDbContext)
        {
            var now = SystemDate.Now;

            foreach (var item in primeDbContext.ChangeTracker.Entries<IChangeDateTrackedEntity>().Where(entity => entity.State == EntityState.Added || entity.State == EntityState.Modified))
            {
                item.Entity.LastChangeDate = now;
            }

            foreach (var item in primeDbContext.ChangeTracker.Entries<ICreateDateTrackedEntity>().Where(entity => entity.State == EntityState.Added))
            {
                item.Entity.CreateDate = now;
            }
        }
    }

}