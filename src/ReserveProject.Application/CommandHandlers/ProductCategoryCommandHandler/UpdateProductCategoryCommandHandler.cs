using ReserveProject.Application.Infrastructure;
using ReserveProject.Domain.Aggregates.ProductCategoryAggregate;
using ReserveProject.Domain.Aggregates.ProductCategoryAggregate.Commands;
using ReserveProject.Infrastructure.Database;
using ReserveProject.Shared.ApplicationInfrastructure;
using System.Threading;
using System.Threading.Tasks;

namespace ReserveProject.Application.CommandHandlers.CustomerCommandHandler
{
    public class UpdateProductCategoryCommandHandler : CommandHandler<UpdateProductCategoryCommand>
    {
        private readonly IUnitOfWork _unitOfWork;

        public UpdateProductCategoryCommandHandler(IUnitOfWork unitOfWork,
                                            PrimeDbContext invoicingDbContext) : base(invoicingDbContext)
        {
            _unitOfWork = unitOfWork;
        }

        public async override Task<CommandExecutionResult> Handle(UpdateProductCategoryCommand request, CancellationToken cancellationToken)
        {
            var productCategory = Entity<ProductCategory>(request.UId);
            var parentId = EntityId<ProductCategory>(request.ParentUId);

            productCategory.Update(request.Name, parentId);
            await _unitOfWork.Save();

            return await Ok(DomainOperationResult.Update(productCategory.UId));
        }
    }
}
