using ReserveProject.Infrastructure.Database;
using ReserveProject.Infrastructure.Repositories.Abstractions;
using ReserveProject.Shared.ApplicationInfrastructure;
using System.Threading;
using System.Threading.Tasks;
using ReserveProject.Application.Infrastructure;
using ReserveProject.Domain.Aggregates.ProductCategoryAggregate;
using ReserveProject.Domain.Aggregates.ProductCategoryAggregate.Commands;

namespace ReserveProject.Application.CommandHandlers.CustomerCommandHandler
{
    public class CreateProductCategoryCommandHandler : CommandHandler<CreateProductCategoryCommand>
    {
        private readonly IProductCategoryRepository _productCategoryRepository;
        private readonly IUnitOfWork _unitOfWork;

        public CreateProductCategoryCommandHandler(PrimeDbContext invoicingDbContext,
                                            IProductCategoryRepository productCategoryRepository,
                                            IUnitOfWork unitOfWork) : base(invoicingDbContext)
        {
            _productCategoryRepository = productCategoryRepository;
            _unitOfWork = unitOfWork;
        }


        public async override Task<CommandExecutionResult> Handle(CreateProductCategoryCommand request, CancellationToken cancellationToken)
        {
            var parentId = EntityId<ProductCategory>(request.ParentUId);
            var productCategory = ProductCategory.Create(request.Name, parentId);

            _productCategoryRepository.Store(productCategory);
            await _unitOfWork.Save();

            return await Ok(DomainOperationResult.Create(productCategory.UId));
        }
    }
}
