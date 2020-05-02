using ReserveProject.Infrastructure.Database;
using ReserveProject.Infrastructure.Repositories.Abstractions;
using ReserveProject.Shared.ApplicationInfrastructure;
using System.Threading;
using System.Threading.Tasks;
using ReserveProject.Application.Infrastructure;
using ReserveProject.Domain.Aggregates.BankAggregate;
using ReserveProject.Domain.Aggregates.BankAggregate.Commands;
using ReserveProject.Domain.Aggregates.Location;

namespace ReserveProject.Application.CommandHandlers.CustomerCommandHandler
{
    public class CreateBankCommandHandler : CommandHandler<CreateBankCommand>
    {
        private readonly IBankRepository _bankRepository;
        private readonly IUnitOfWork _unitOfWork;

        public CreateBankCommandHandler(PrimeDbContext invoicingDbContext,
                                            IBankRepository bankRepository,
                                            IUnitOfWork unitOfWork) : base(invoicingDbContext)
        {
            _bankRepository = bankRepository;
            _unitOfWork = unitOfWork;
        }


        public async override Task<CommandExecutionResult> Handle(CreateBankCommand request, CancellationToken cancellationToken)
        {
            var cityId = ExistingEntityId<City>(request.CityUId);
            var bank = Bank.Create(request.Name, request.IdentifierCode, request.Street, request.StreetInDetails, 
                cityId, request.ZipCode, request.IsActive, request.Phone, request.Email);

            _bankRepository.Store(bank);
            await _unitOfWork.Save();

            return await Ok(DomainOperationResult.Create(bank.UId));
        }
    }
}
