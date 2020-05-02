using System.Collections.Generic;
using System.Threading.Tasks;
using MediatR;
using ReserveProject.Shared.DomainInfrastructure;

namespace ReserveProject.Infrastructure.EventDispatching
{
    public class TransactionalDomainEventDispatcher : IEventDispatcher<DomainEvent>
    {
        public async Task Dispatch(IReadOnlyList<DomainEvent> domainEvents, IMediator mediator)
        {
            foreach (var item in domainEvents) await mediator.Publish(item);
        }
    }
}