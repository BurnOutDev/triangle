using ReserveProject.Application.Infrastructure;
using ReserveProject.Domain.Aggregates.PaymentTermAggregate;
using ReserveProject.Domain.Aggregates.PaymentTermAggregate.Commands;
using ReserveProject.Infrastructure.Database;
using ReserveProject.Shared.ApplicationInfrastructure;
using System.Threading;
using System.Threading.Tasks;

namespace ReserveProject.Application.CommandHandlers.CustomerCommandHandler
{
    public class DeletePaymentTermCommandHandler : CommandHandler<DeletePaymentTermCommand>
    {
        private readonly IUnitOfWork _unitOfWork;

        public DeletePaymentTermCommandHandler(IUnitOfWork unitOfWork,
                                            PrimeDbContext invoicingDbContext) : base(invoicingDbContext)
        {
            _unitOfWork = unitOfWork;
        }

        public async override Task<CommandExecutionResult> Handle(DeletePaymentTermCommand request, CancellationToken cancellationToken)
        {
            var paymentTerm = Entity<PaymentTerm>(request.UId);

            paymentTerm.Delete();
            await _unitOfWork.Save();

            return await Ok(DomainOperationResult.UpdateEmpty());
        }
    }
}
