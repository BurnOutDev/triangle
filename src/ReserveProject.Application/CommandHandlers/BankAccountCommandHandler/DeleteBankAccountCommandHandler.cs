using ReserveProject.Application.Infrastructure;
using ReserveProject.Domain.Aggregates.BankAccountAggregate;
using ReserveProject.Domain.Aggregates.BankAccountAggregate.Commands;
using ReserveProject.Infrastructure.Database;
using ReserveProject.Shared.ApplicationInfrastructure;
using System.Threading;
using System.Threading.Tasks;

namespace ReserveProject.Application.CommandHandlers.CustomerCommandHandler
{
    public class DeleteBankAccountCommandHandler : CommandHandler<DeleteBankAccountCommand>
    {
        private readonly IUnitOfWork _unitOfWork;

        public DeleteBankAccountCommandHandler(IUnitOfWork unitOfWork,
                                            PrimeDbContext invoicingDbContext) : base(invoicingDbContext)
        {
            _unitOfWork = unitOfWork;
        }

        public async override Task<CommandExecutionResult> Handle(DeleteBankAccountCommand request, CancellationToken cancellationToken)
        {
            var bankAccount = Entity<BankAccount>(request.UId);

            bankAccount.Delete();
            await _unitOfWork.Save();

            return await Ok(DomainOperationResult.UpdateEmpty());
        }
    }
}
