using ReserveProject.Application.Infrastructure;
using ReserveProject.Domain.Aggregates.BankAggregate;
using ReserveProject.Domain.Aggregates.BankAggregate.Commands;
using ReserveProject.Infrastructure.Database;
using ReserveProject.Shared.ApplicationInfrastructure;
using System.Threading;
using System.Threading.Tasks;

namespace ReserveProject.Application.CommandHandlers.CustomerCommandHandler
{
    public class DeleteBankCommandHandler : CommandHandler<DeleteBankCommand>
    {
        private readonly IUnitOfWork _unitOfWork;

        public DeleteBankCommandHandler(IUnitOfWork unitOfWork,
                                            PrimeDbContext invoicingDbContext) : base(invoicingDbContext)
        {
            _unitOfWork = unitOfWork;
        }

        public async override Task<CommandExecutionResult> Handle(DeleteBankCommand request, CancellationToken cancellationToken)
        {
            var bank = Entity<Bank>(request.UId);

            bank.Delete();
            await _unitOfWork.Save();

            return await Ok(DomainOperationResult.UpdateEmpty());
        }
    }
}
