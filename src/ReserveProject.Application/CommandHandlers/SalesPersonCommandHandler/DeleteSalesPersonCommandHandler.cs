using ReserveProject.Application.Infrastructure;
using ReserveProject.Domain.Aggregates.SalesPersonAggregate;
using ReserveProject.Domain.Aggregates.SalesPersonAggregate.Commands;
using ReserveProject.Infrastructure.Database;
using ReserveProject.Shared.ApplicationInfrastructure;
using System.Threading;
using System.Threading.Tasks;

namespace ReserveProject.Application.CommandHandlers.CustomerCommandHandler
{
    public class DeleteSalesPersonCommandHandler : CommandHandler<DeleteSalesPersonCommand>
    {
        private readonly IUnitOfWork _unitOfWork;

        public DeleteSalesPersonCommandHandler(IUnitOfWork unitOfWork,
                                            PrimeDbContext invoicingDbContext) : base(invoicingDbContext)
        {
            _unitOfWork = unitOfWork;
        }

        public async override Task<CommandExecutionResult> Handle(DeleteSalesPersonCommand request, CancellationToken cancellationToken)
        {
            var salesPerson= Entity<SalesPerson>(request.UId);

            salesPerson.Delete();
            await _unitOfWork.Save();

            return await Ok(DomainOperationResult.UpdateEmpty());
        }
    }
}
