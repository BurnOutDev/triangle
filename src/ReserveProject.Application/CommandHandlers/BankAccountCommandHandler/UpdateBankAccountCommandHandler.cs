using ReserveProject.Application.Infrastructure;
using ReserveProject.Domain.Aggregates.BankAccountAggregate;
using ReserveProject.Domain.Aggregates.BankAccountAggregate.Commands;
using ReserveProject.Domain.Aggregates.BankAggregate;
using ReserveProject.Domain.Aggregates.Location;
using ReserveProject.Infrastructure.Database;
using ReserveProject.Shared.ApplicationInfrastructure;
using System.Threading;
using System.Threading.Tasks;

namespace ReserveProject.Application.CommandHandlers.CustomerCommandHandler
{
    public class UpdateBankAccountCommandHandler : CommandHandler<UpdateBankAccountCommand>
    {
        private readonly IUnitOfWork _unitOfWork;

        public UpdateBankAccountCommandHandler(IUnitOfWork unitOfWork,
                                            PrimeDbContext invoicingDbContext) : base(invoicingDbContext)
        {
            _unitOfWork = unitOfWork;
        }

        public async override Task<CommandExecutionResult> Handle(UpdateBankAccountCommand request, CancellationToken cancellationToken)
        {
            var bankAccount = Entity<BankAccount>(request.UId);
            var bankId = ExistingEntityId<Bank>(request.BankUId);

            bankAccount.Update(request.Name, request.Number, bankId);
            await _unitOfWork.Save();

            return await Ok(DomainOperationResult.Update(bankAccount.UId));
        }
    }
}
