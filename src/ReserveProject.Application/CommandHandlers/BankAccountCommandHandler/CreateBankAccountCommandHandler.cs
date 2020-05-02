using ReserveProject.Infrastructure.Database;
using ReserveProject.Infrastructure.Repositories.Abstractions;
using ReserveProject.Shared.ApplicationInfrastructure;
using System.Threading;
using System.Threading.Tasks;
using ReserveProject.Application.Infrastructure;
using ReserveProject.Domain.Aggregates.BankAccountAggregate;
using ReserveProject.Domain.Aggregates.BankAccountAggregate.Commands;
using ReserveProject.Domain.Aggregates.Location;
using ReserveProject.Domain.Aggregates.BankAggregate;

namespace ReserveProject.Application.CommandHandlers.CustomerCommandHandler
{
    public class CreateBankAccountCommandHandler : CommandHandler<CreateBankAccountCommand>
    {
        private readonly IBankAccountRepository _bankAccountRepository;
        private readonly IUnitOfWork _unitOfWork;

        public CreateBankAccountCommandHandler(PrimeDbContext invoicingDbContext,
                                            IBankAccountRepository bankAccountRepository,
                                            IUnitOfWork unitOfWork) : base(invoicingDbContext)
        {
            _bankAccountRepository = bankAccountRepository;
            _unitOfWork = unitOfWork;
        }


        public async override Task<CommandExecutionResult> Handle(CreateBankAccountCommand request, CancellationToken cancellationToken)
        {
            var bankId = ExistingEntityId<Bank>(request.BankUId);
            var bankAccount = BankAccount.Create(request.Name, request.Number, bankId);

            _bankAccountRepository.Store(bankAccount);
            await _unitOfWork.Save();

            return await Ok(DomainOperationResult.Create(bankAccount.UId));
        }
    }
}
