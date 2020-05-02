using ReserveProject.Infrastructure.Database;
using ReserveProject.Infrastructure.Repositories.Abstractions;
using ReserveProject.Shared.ApplicationInfrastructure;
using System.Threading;
using System.Threading.Tasks;
using ReserveProject.Application.Infrastructure;
using ReserveProject.Domain.Aggregates.PaymentTermAggregate;
using ReserveProject.Domain.Aggregates.PaymentTermAggregate.Commands;
using ReserveProject.Domain.Aggregates.Location;
using ReserveProject.Domain.Aggregates.BankAggregate;

namespace ReserveProject.Application.CommandHandlers.CustomerCommandHandler
{
    public class CreatePaymentTermCommandHandler : CommandHandler<CreatePaymentTermCommand>
    {
        private readonly IPaymentTermRepository _paymentTermRepository;
        private readonly IUnitOfWork _unitOfWork;

        public CreatePaymentTermCommandHandler(PrimeDbContext invoicingDbContext,
                                            IPaymentTermRepository paymentTermRepository,
                                            IUnitOfWork unitOfWork) : base(invoicingDbContext)
        {
            _paymentTermRepository = paymentTermRepository;
            _unitOfWork = unitOfWork;
        }


        public async override Task<CommandExecutionResult> Handle(CreatePaymentTermCommand request, CancellationToken cancellationToken)
        {
            var paymentTerm = PaymentTerm.Create(request.Name, request.Description, request.DaysCount);

            _paymentTermRepository.Store(paymentTerm);
            await _unitOfWork.Save();

            return await Ok(DomainOperationResult.Create(paymentTerm.UId));
        }
    }
}
