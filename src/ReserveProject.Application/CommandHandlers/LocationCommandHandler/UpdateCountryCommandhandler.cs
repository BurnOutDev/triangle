using System.Threading;
using System.Threading.Tasks;
using ReserveProject.Application.Infrastructure;
using ReserveProject.Infrastructure.Database;
using ReserveProject.Shared.ApplicationInfrastructure;
using ReserveProject.Domain.Aggregates.Location.Commands;
using ReserveProject.Domain.Aggregates.Location;

namespace ReserveProject.Application.CommandHandlers.Location
{
    public class UpdateCountryCommandhandler : CommandHandler<UpdateCountryCommand>
    {
        private readonly IUnitOfWork _unitOfWork;

        public UpdateCountryCommandhandler(IUnitOfWork unitOfWork, PrimeDbContext invoicingDbContext) : base(invoicingDbContext)
        {
            this._unitOfWork = unitOfWork;
        }

        public override async Task<CommandExecutionResult> Handle(UpdateCountryCommand request, CancellationToken cancellationToken)
        {
            var country = Entity<Country>(request.UId);
            country.Update(request.Name, request.CountryCode);
            await _unitOfWork.Save();
            return await Ok(DomainOperationResult.Create(country.UId));
        }
    }
}
