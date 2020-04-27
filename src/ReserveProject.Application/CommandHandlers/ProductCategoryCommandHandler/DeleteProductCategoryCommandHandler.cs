using ReserveProject.Application.Infrastructure;
using ReserveProject.Domain.Aggregates.ProductCategoryAggregate;
using ReserveProject.Domain.Aggregates.ProductCategoryAggregate.Commands;
using ReserveProject.Infrastructure.Database;
using ReserveProject.Shared.ApplicationInfrastructure;
using System.Threading;
using System.Threading.Tasks;

namespace ReserveProject.Application.CommandHandlers.CustomerCommandHandler
{
    public class DeleteProductCategoryCommandHandler : CommandHandler<DeleteProductCategoryCommand>
    {
        private readonly IUnitOfWork _unitOfWork;

        public DeleteProductCategoryCommandHandler(IUnitOfWork unitOfWork,
                                            PrimeDbContext invoicingDbContext) : base(invoicingDbContext)
        {
            _unitOfWork = unitOfWork;
        }

        public async override Task<CommandExecutionResult> Handle(DeleteProductCategoryCommand request, CancellationToken cancellationToken)
        {
            var tax= Entity<ProductCategory>(request.UId);

            tax.Delete();
            await _unitOfWork.Save();

            return await Ok(DomainOperationResult.UpdateEmpty());
        }
    }
}
