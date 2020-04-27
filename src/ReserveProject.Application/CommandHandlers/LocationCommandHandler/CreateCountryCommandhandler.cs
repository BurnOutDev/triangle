using System.Threading;
using System.Threading.Tasks;
using ReserveProject.Application.Infrastructure;
using ReserveProject.Infrastructure.Database;
using ReserveProject.Infrastructure.Repositories.Abstractions;
using ReserveProject.Shared.ApplicationInfrastructure;
using ReserveProject.Domain.Aggregates.Location;
using ReserveProject.Domain.Aggregates.Location.Commands;

namespace ReserveProject.Application.CommandHandlers.Location
{
    public class CreateCountryCommandhandler : CommandHandler<CreateCountryCommand>
    {
        private readonly ICountryRepository _countryRepository;
        private readonly IUnitOfWork _unitOfWork;

        public CreateCountryCommandhandler(ICountryRepository countryRepository, PrimeDbContext invoicingDbContext, IUnitOfWork unitOfWork) : base(invoicingDbContext)
        {
            this._countryRepository = countryRepository;
            this._unitOfWork = unitOfWork;
        }

        public override async Task<CommandExecutionResult> Handle(CreateCountryCommand request, CancellationToken cancellationToken)
        {
            var country = Country.Create(request.Name, request.CountryCode);
            _countryRepository.Store(country);
            await _unitOfWork.Save();
            return await Ok(DomainOperationResult.Create(country.UId));
        }
    }
}
