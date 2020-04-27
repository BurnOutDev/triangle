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
    public class EditCurrencyCommandHandler : CommandHandler<EditCurrencyCommand>
    {
        private readonly IUnitOfWork _unitOfWork;

        public EditCurrencyCommandHandler(IUnitOfWork unitOfWork, PrimeDbContext primeDbContext) : base(primeDbContext)
        {
            _unitOfWork = unitOfWork;
        }

        public override async Task<CommandExecutionResult> Handle(EditCurrencyCommand request, CancellationToken cancellationToken)
        {
            var currency = Entity<Currency>(request.UId);

            currency.Edit(request.UId, request.Name, request.Code, request.Symbol);
            await _unitOfWork.Save();

            return await Ok(DomainOperationResult.Update(currency.UId));
        }
    }
}
