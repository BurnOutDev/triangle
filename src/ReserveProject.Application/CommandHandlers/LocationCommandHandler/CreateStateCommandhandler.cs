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
    public class CreateStateCommandhandler : CommandHandler<CreateStateCommand>
    {
        private readonly IStateRepository _stateRepository;
        private readonly IUnitOfWork _unitOfWork;

        public CreateStateCommandhandler(IStateRepository stateRepository, PrimeDbContext invoicingDbContext, IUnitOfWork unitOfWork) : base(invoicingDbContext)
        {
            this._stateRepository = stateRepository;
            this._unitOfWork = unitOfWork;
        }

        public override async Task<CommandExecutionResult> Handle(CreateStateCommand request, CancellationToken cancellationToken)
        {
            var countryId = ExistingEntityId<Country>(request.CountryUId);
            var state = State.Create(request.Name, countryId);
            _stateRepository.Store(state);
            await _unitOfWork.Save();
            return await Ok(DomainOperationResult.Create(state.UId));
        }
    }
}
