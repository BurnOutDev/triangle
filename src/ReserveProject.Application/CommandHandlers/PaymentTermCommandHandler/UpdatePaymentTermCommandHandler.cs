using ReserveProject.Application.Infrastructure;
using ReserveProject.Domain.Aggregates.PaymentTermAggregate;
using ReserveProject.Domain.Aggregates.PaymentTermAggregate.Commands;
using ReserveProject.Domain.Aggregates.BankAggregate;
using ReserveProject.Domain.Aggregates.Location;
using ReserveProject.Infrastructure.Database;
using ReserveProject.Shared.ApplicationInfrastructure;
using System.Threading;
using System.Threading.Tasks;

namespace ReserveProject.Application.CommandHandlers.CustomerCommandHandler
{
    public class UpdatePaymentTermCommandHandler : CommandHandler<UpdatePaymentTermCommand>
    {
        private readonly IUnitOfWork _unitOfWork;

        public UpdatePaymentTermCommandHandler(IUnitOfWork unitOfWork,
                                            PrimeDbContext invoicingDbContext) : base(invoicingDbContext)
        {
            _unitOfWork = unitOfWork;
        }

        public async override Task<CommandExecutionResult> Handle(UpdatePaymentTermCommand request, CancellationToken cancellationToken)
        {
            var paymentTerm = Entity<PaymentTerm>(request.UId);

            paymentTerm.Update(request.Name, request.Description, request.DaysCount);
            await _unitOfWork.Save();

            return await Ok(DomainOperationResult.Update(paymentTerm.UId));
        }
    }
}
