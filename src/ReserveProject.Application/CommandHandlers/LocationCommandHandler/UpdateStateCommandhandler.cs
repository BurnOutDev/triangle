using System.Threading;
using System.Threading.Tasks;
using ReserveProject.Application.Infrastructure;
using ReserveProject.Infrastructure.Database;
using ReserveProject.Shared.ApplicationInfrastructure;
using ReserveProject.Domain.Aggregates.Location.Commands;
using ReserveProject.Domain.Aggregates.Location;

namespace ReserveProject.Application.CommandHandlers.Location
{
    public class UpdateStateCommandhandler : CommandHandler<UpdateStateCommand>
    {
        private readonly IUnitOfWork _unitOfWork;

        public UpdateStateCommandhandler(IUnitOfWork unitOfWork, PrimeDbContext invoicingDbContext) : base(invoicingDbContext)
        {
            this._unitOfWork = unitOfWork;
        }

        public override async Task<CommandExecutionResult> Handle(UpdateStateCommand request, CancellationToken cancellationToken)
        {
            var state = Entity<State>(request.UId);
            var countryId = ExistingEntityId<Country>(request.CountryUId);
            state.Update(request.Name, countryId);
            await _unitOfWork.Save();
            return await Ok(DomainOperationResult.Create(state.UId));
        }
    }
}
