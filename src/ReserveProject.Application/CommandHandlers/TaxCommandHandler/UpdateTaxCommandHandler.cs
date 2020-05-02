using ReserveProject.Application.Infrastructure;
using ReserveProject.Domain.Aggregates.TaxAggregate;
using ReserveProject.Domain.Aggregates.TaxAggregate.Commands;
using ReserveProject.Infrastructure.Database;
using ReserveProject.Shared.ApplicationInfrastructure;
using System.Threading;
using System.Threading.Tasks;

namespace ReserveProject.Application.CommandHandlers.CustomerCommandHandler
{
    public class UpdateTaxCommandHandler : CommandHandler<UpdateTaxCommand>
    {
        private readonly IUnitOfWork _unitOfWork;

        public UpdateTaxCommandHandler(IUnitOfWork unitOfWork,
                                            PrimeDbContext invoicingDbContext) : base(invoicingDbContext)
        {
            _unitOfWork = unitOfWork;
        }

        public async override Task<CommandExecutionResult> Handle(UpdateTaxCommand request, CancellationToken cancellationToken)
        {
            var tax = Entity<Tax>(request.UId);

            tax.Update(request.Name, request.Scope, request.Computation, request.Value);
            await _unitOfWork.Save();

            return await Ok(DomainOperationResult.Update(tax.UId));
        }
    }
}
