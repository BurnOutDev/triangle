using System.Threading;
using System.Threading.Tasks;
using ReserveProject.Application.Infrastructure;
using ReserveProject.Infrastructure.Database;
using ReserveProject.Shared.ApplicationInfrastructure;
using ReserveProject.Domain.Aggregates.Location.Commands;
using ReserveProject.Domain.Aggregates.Location;

namespace ReserveProject.Application.CommandHandlers.Location
{
    public class DeleteCityCommandhandler : CommandHandler<DeleteCityCommand>
    {
        private readonly IUnitOfWork _unitOfWork;

        public DeleteCityCommandhandler(IUnitOfWork unitOfWork, PrimeDbContext invoicingDbContext):base(invoicingDbContext)
        {
            this._unitOfWork = unitOfWork;
        }

        public override async Task<CommandExecutionResult> Handle(DeleteCityCommand request, CancellationToken cancellationToken)
        {
            var city = Entity<City>(request.UId);
            city.Delete();
            await _unitOfWork.Save();
            return await Ok(DomainOperationResult.Create(city.UId));
        }
    }
}
