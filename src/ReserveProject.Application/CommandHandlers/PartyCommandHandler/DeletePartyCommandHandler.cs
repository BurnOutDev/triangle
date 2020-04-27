using ReserveProject.Application.Infrastructure;
using ReserveProject.Domain.Aggregates.PartyAggregate;
using ReserveProject.Domain.Aggregates.PartyAggregate.Commands;
using ReserveProject.Infrastructure.Database;
using ReserveProject.Shared.ApplicationInfrastructure;
using System.Threading;
using System.Threading.Tasks;

namespace ReserveProject.Application.CommandHandlers.CustomerCommandHandler
{
    public class DeletePartyCommandHandler : CommandHandler<DeletePartyCommand>
    {
        private readonly IUnitOfWork _unitOfWork;

        public DeletePartyCommandHandler(IUnitOfWork unitOfWork,
                                            PrimeDbContext invoicingDbContext) : base(invoicingDbContext)
        {
            _unitOfWork = unitOfWork;
        }

        public async override Task<CommandExecutionResult> Handle(DeletePartyCommand request, CancellationToken cancellationToken)
        {
            var party= Entity<Party>(request.UId);

            party.Delete();
            await _unitOfWork.Save();

            return await Ok(DomainOperationResult.UpdateEmpty());
        }
    }
}
