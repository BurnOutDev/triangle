using ReserveProject.Application.Infrastructure;
using ReserveProject.Domain.Aggregates.TaxAggregate;
using ReserveProject.Domain.Aggregates.TaxAggregate.Commands;
using ReserveProject.Infrastructure.Database;
using ReserveProject.Shared.ApplicationInfrastructure;
using System.Threading;
using System.Threading.Tasks;

namespace ReserveProject.Application.CommandHandlers.CustomerCommandHandler
{
    public class DeleteTaxCommandHandler : CommandHandler<DeleteTaxCommand>
    {
        private readonly IUnitOfWork _unitOfWork;

        public DeleteTaxCommandHandler(IUnitOfWork unitOfWork,
                                            PrimeDbContext invoicingDbContext) : base(invoicingDbContext)
        {
            _unitOfWork = unitOfWork;
        }

        public async override Task<CommandExecutionResult> Handle(DeleteTaxCommand request, CancellationToken cancellationToken)
        {
            var tax= Entity<Tax>(request.UId);

            tax.Delete();
            await _unitOfWork.Save();

            return await Ok(DomainOperationResult.UpdateEmpty());
        }
    }
}
