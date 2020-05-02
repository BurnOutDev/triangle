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
    public class CreateCityCommandhandler : CommandHandler<CreateCityCommand>
    {
        private readonly ICityRepository _cityRepository;
        private readonly IUnitOfWork _unitOfWork;

        public CreateCityCommandhandler(ICityRepository cityRepository, PrimeDbContext invoicingDbContext, IUnitOfWork unitOfWork) : base(invoicingDbContext)
        {
            this._cityRepository = cityRepository;
            this._unitOfWork = unitOfWork;
        }

        public override async Task<CommandExecutionResult> Handle(CreateCityCommand request, CancellationToken cancellationToken)
        {
            var stateId = ExistingEntityId<State>(request.StateUId);
            var city = City.Create(request.Name, stateId);
            _cityRepository.Store(city);
            await _unitOfWork.Save();
            return await Ok(DomainOperationResult.Create(city.UId));
        }
    }
}
