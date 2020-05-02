using System.Threading;
using System.Threading.Tasks;
using ReserveProject.Application.Infrastructure;
using ReserveProject.Infrastructure.Database;
using ReserveProject.Infrastructure.Repositories.Abstractions;
using ReserveProject.Shared.ApplicationInfrastructure;
using ReserveProject.Domain.Aggregates.CurrencyAggregate;
using ReserveProject.Domain.Aggregates.CurrencyAggregate.Commands;

namespace ReserveProject.Application.CommandHandlers.CurrencyCommandHandler
{
    public class DeleteCurrencyCommandHandler : CommandHandler<DeleteCurrencyCommand>
    {
        private readonly IUnitOfWork _unitOfWork;

        public DeleteCurrencyCommandHandler(IUnitOfWork unitOfWork, PrimeDbContext primeDbContext) : base(primeDbContext)
        {
            _unitOfWork = unitOfWork;
        }

        public override async Task<CommandExecutionResult> Handle(DeleteCurrencyCommand request, CancellationToken cancellationToken)
        {
            var currency = Entity<Currency>(request.UId);

            currency.Delete();
            await _unitOfWork.Save();

            return await Ok(DomainOperationResult.Update(currency.UId));
        }
    }
}
