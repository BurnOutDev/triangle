using System.Threading;
using System.Threading.Tasks;
using ReserveProject.Application.Infrastructure;
using ReserveProject.Infrastructure.Database;
using ReserveProject.Shared.ApplicationInfrastructure;
using ReserveProject.Domain.Aggregates.Location.Commands;
using ReserveProject.Domain.Aggregates.Location;

namespace ReserveProject.Application.CommandHandlers.Location
{
    public class DeleteStateCommandhandler : CommandHandler<DeleteStateCommand>
    {
        private readonly IUnitOfWork _unitOfWork;

        public DeleteStateCommandhandler(IUnitOfWork unitOfWork, PrimeDbContext invoicingDbContext) : base(invoicingDbContext)
        {
            this._unitOfWork = unitOfWork;
        }

        public override async Task<CommandExecutionResult> Handle(DeleteStateCommand request, CancellationToken cancellationToken)
        {
            var state = Entity<State>(request.UId);
            state.Delete();
            await _unitOfWork.Save();
            return await Ok(DomainOperationResult.Create(state.UId));
        }
    }
}
