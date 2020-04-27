using System.Threading;
using System.Threading.Tasks;
using ReserveProject.Application.Infrastructure;
using ReserveProject.Infrastructure.Database;
using ReserveProject.Shared.ApplicationInfrastructure;
using ReserveProject.Domain.Aggregates.Location.Commands;
using ReserveProject.Domain.Aggregates.Location;

namespace ReserveProject.Application.CommandHandlers.Location
{
    public class DeleteCountryCommandhandler : CommandHandler<DeleteCountryCommand>
    {
        private readonly IUnitOfWork _unitOfWork;

        public DeleteCountryCommandhandler(IUnitOfWork unitOfWork, PrimeDbContext invoicingDbContext) : base(invoicingDbContext)
        {
            this._unitOfWork = unitOfWork;
        }

        public override async Task<CommandExecutionResult> Handle(DeleteCountryCommand request, CancellationToken cancellationToken)
        {
            var country = Entity<Country>(request.UId);
            country.Delete();
            await _unitOfWork.Save();
            return await Ok(DomainOperationResult.Create(country.UId));
        }
    }
}
