using ReserveProject.Application.Infrastructure;
using ReserveProject.Domain.Aggregates.CustomerAggregate;
using ReserveProject.Domain.Aggregates.CustomerAggregate.Commands;
using ReserveProject.Infrastructure.Database;
using ReserveProject.Infrastructure.Repositories.Abstractions;
using ReserveProject.Shared.ApplicationInfrastructure;
using Microsoft.Extensions.Configuration;
using System.Threading;
using System.Threading.Tasks;

namespace ReserveProject.Application.CommandHandlers.CustomerCommandHandler
{
    public class DeleteCustomerCommandHandler : CommandHandler<DeleteCustomerCommand>
    {
        private readonly IUnitOfWork _unitOfWork;

        public DeleteCustomerCommandHandler(IUnitOfWork unitOfWork,
                                            PrimeDbContext invoicingDbContext) : base(invoicingDbContext)
        {
            _unitOfWork = unitOfWork;
        }

        public async override Task<CommandExecutionResult> Handle(DeleteCustomerCommand request, CancellationToken cancellationToken)
        {
            var customer = Entity<Customer>(request.UId);

            customer.Delete();
            await _unitOfWork.Save();

            return await Ok(DomainOperationResult.CreateEmpty());
        }
    }
}
