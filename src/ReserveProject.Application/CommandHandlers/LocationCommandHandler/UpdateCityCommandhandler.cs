using System.Threading;
using System.Threading.Tasks;
using ReserveProject.Application.Infrastructure;
using ReserveProject.Infrastructure.Database;
using ReserveProject.Shared.ApplicationInfrastructure;
using ReserveProject.Domain.Aggregates.Location.Commands;
using ReserveProject.Domain.Aggregates.Location;

namespace ReserveProject.Application.CommandHandlers.Location
{
    public class UpdateCityCommandhandler : CommandHandler<UpdateCityCommand>
    {
        private readonly IUnitOfWork _unitOfWork;

        public UpdateCityCommandhandler(IUnitOfWork unitOfWork, PrimeDbContext invoicingDbContext) : base(invoicingDbContext)
        {
            this._unitOfWork = unitOfWork;
        }

        public override async Task<CommandExecutionResult> Handle(UpdateCityCommand request, CancellationToken cancellationToken)
        {
            var city = Entity<City>(request.UId);
            var stateId = ExistingEntityId<State>(request.StateUId);
            city.Update(request.Name, stateId);
            await _unitOfWork.Save();
            return await Ok(DomainOperationResult.Create(city.UId));
        }
    }
}
