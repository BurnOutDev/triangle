using ReserveProject.Application.Infrastructure;
using ReserveProject.Domain.Aggregates.InvoiceAggregate;
using ReserveProject.Domain.Aggregates.InvoiceAggregate.Commands;
using ReserveProject.Infrastructure.Database;
using ReserveProject.Shared.ApplicationInfrastructure;
using System.Threading;
using System.Threading.Tasks;

namespace ReserveProject.Application.CommandHandlers.CustomerCommandHandler
{
    public class DeleteInvoiceCommandHandler : CommandHandler<DeleteInvoiceCommand>
    {
        private readonly IUnitOfWork _unitOfWork;

        public DeleteInvoiceCommandHandler(IUnitOfWork unitOfWork,
                                            PrimeDbContext invoicingDbContext) : base(invoicingDbContext)
        {
            _unitOfWork = unitOfWork;
        }

        public async override Task<CommandExecutionResult> Handle(DeleteInvoiceCommand request, CancellationToken cancellationToken)
        {
            var invoice= Entity<Invoice>(request.UId);

            invoice.Delete();
            await _unitOfWork.Save();

            return await Ok(DomainOperationResult.UpdateEmpty());
        }
    }
}
