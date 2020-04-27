using System.Threading;
using System.Threading.Tasks;
using ReserveProject.Domain.Aggregates.CustomerAggregate.Events;
using ReserveProject.Shared.DomainInfrastructure;

namespace ReserveProject.Application.EventHandlers
{
    public class CustomerEventHandler : ISynchronousDomainEventHandler<CustomerCreatedDomainEvent>
    {
        public Task Handle(CustomerCreatedDomainEvent notification, CancellationToken cancellationToken)
        {
            return Task.FromResult(0);
        }
    }
}