using ReserveProject.Infrastructure.Database;
using ReserveProject.Infrastructure.Repositories.Abstractions;
using ReserveProject.Shared.ApplicationInfrastructure;
using System.Threading;
using System.Threading.Tasks;
using ReserveProject.Application.Infrastructure;
using ReserveProject.Domain.Aggregates.PartyAggregate;
using ReserveProject.Domain.Aggregates.PartyAggregate.Commands;
using ReserveProject.Application.Services;
using ReserveProject.Domain.Aggregates.Location;
using System.Linq;

namespace ReserveProject.Application.CommandHandlers.CustomerCommandHandler
{
    public class CreatePartyCommandHandler : CommandHandler<CreatePartyCommand>
    {
        private readonly IPartyRepository _productRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly BankAccountExtractorService bankAccountExtractorService;

        public CreatePartyCommandHandler(PrimeDbContext invoicingDbContext,
                                            IPartyRepository productRepository,
                                            IBankAccountRepository bankAccountRepository,
                                            IUnitOfWork unitOfWork) : base(invoicingDbContext)
        {
            _productRepository = productRepository;
            _unitOfWork = unitOfWork;
            bankAccountExtractorService = new BankAccountExtractorService(bankAccountRepository);
        }


        public async override Task<CommandExecutionResult> Handle(CreatePartyCommand request, CancellationToken cancellationToken)
        {
            var cityId = ExistingEntityId<City>(request.CityUId);
            var bankAccounts = bankAccountExtractorService.Extract(request.BankAccountUIds);

            var product = Party.Create(request.Name, request.Type, request.Street, request.StreetDetails,
                request.Role, cityId, request.TaxCode, request.Phone, request.Mobile, request.Email, request.Language, bankAccounts.ToList());

            _productRepository.Store(product);
            await _unitOfWork.Save();

            return await Ok(DomainOperationResult.Create(product.UId));
        }
    }
}
