using ReserveProject.Application.Infrastructure;
using ReserveProject.Domain.Aggregates.ProductAggregate;
using ReserveProject.Domain.Aggregates.ProductAggregate.Commands;
using ReserveProject.Infrastructure.Database;
using ReserveProject.Shared.ApplicationInfrastructure;
using System.Threading;
using System.Threading.Tasks;

namespace ReserveProject.Application.CommandHandlers.CustomerCommandHandler
{
    public class DeleteProductCommandHandler : CommandHandler<DeleteProductCommand>
    {
        private readonly IUnitOfWork _unitOfWork;

        public DeleteProductCommandHandler(IUnitOfWork unitOfWork,
                                            PrimeDbContext invoicingDbContext) : base(invoicingDbContext)
        {
            _unitOfWork = unitOfWork;
        }

        public async override Task<CommandExecutionResult> Handle(DeleteProductCommand request, CancellationToken cancellationToken)
        {
            var product= Entity<Product>(request.UId);

            product.Delete();
            await _unitOfWork.Save();

            return await Ok(DomainOperationResult.UpdateEmpty());
        }
    }
}
