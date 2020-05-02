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
    public class CreateCurrencyCommandHandler : CommandHandler<CreateCurrencyCommand>
    {
        private readonly ICurrencyRepository _currencyRepository;
        private readonly IUnitOfWork _unitOfWork;

        public CreateCurrencyCommandHandler(ICurrencyRepository currencyRepository, IUnitOfWork unitOfWork)
        {
            _currencyRepository = currencyRepository;
            _unitOfWork = unitOfWork;
        }

        public override async Task<CommandExecutionResult> Handle(CreateCurrencyCommand request, CancellationToken cancellationToken)
        {
            Currency currency = Currency.Create(request.Name, request.Code, request.Symbol);

            _currencyRepository.Store(currency);
            await _unitOfWork.Save();

            return await Ok(DomainOperationResult.Create(currency.UId));
        }
    }
}
