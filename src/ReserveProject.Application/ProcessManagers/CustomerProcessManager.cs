using System.Threading;
using System.Threading.Tasks;
using ReserveProject.Application.Execution;
using ReserveProject.Domain.Aggregates.CustomerAggregate.Events;
using ReserveProject.Infrastructure.Database;
using ReserveProject.Shared.DomainInfrastructure;

namespace ReserveProject.Application.ProcessManagers
{
    public class CustomerProcessManager : IAsynchronousDomainEventHandler<CustomerCreatedDomainEvent>
    {
        private readonly PrimeDbContext _invoicingDbContext;
        private readonly ICommandExecutor _commandExecutor;

        public CustomerProcessManager(PrimeDbContext invoicingDbContext, ICommandExecutor commandExecutor)
        {
            _invoicingDbContext = invoicingDbContext;
            _commandExecutor = commandExecutor;
        }

        public Task Handle(CustomerCreatedDomainEvent notification, CancellationToken cancellationToken)
        {
            return Task.FromResult(0);
        }
    }
}