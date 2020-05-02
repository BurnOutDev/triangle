using ReserveProject.Infrastructure.Database;
using ReserveProject.Infrastructure.Repositories.Abstractions;
using ReserveProject.Shared.ApplicationInfrastructure;
using System.Threading;
using System.Threading.Tasks;
using ReserveProject.Application.Infrastructure;
using ReserveProject.Domain.Aggregates.ProductAggregate;
using ReserveProject.Domain.Aggregates.ProductAggregate.Commands;
using ReserveProject.Domain.Aggregates.ProductCategoryAggregate;
using ReserveProject.Application.Services;

namespace ReserveProject.Application.CommandHandlers.CustomerCommandHandler
{
    public class CreateProductCommandHandler : CommandHandler<CreateProductCommand>
    {
        private readonly IProductRepository _productRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly TaxExtractorService taxExtractorService;

        public CreateProductCommandHandler(PrimeDbContext invoicingDbContext,
                                            IProductRepository productRepository,
                                            ITaxRepository taxRepository,
                                            IUnitOfWork unitOfWork) : base(invoicingDbContext)
        {
            _productRepository = productRepository;
            _unitOfWork = unitOfWork;
            taxExtractorService = new TaxExtractorService(taxRepository);
        }


        public async override Task<CommandExecutionResult> Handle(CreateProductCommand request, CancellationToken cancellationToken)
        {
            var productCategoryId = ExistingEntityId<ProductCategory>(request.CategoryUId);
            var taxes = taxExtractorService.Extract(request.TaxUIds);

            var product = Product.Create(request.Name, request.Role, request.Type,
                request.BarCode, productCategoryId, request.SalesPrice, request.Cost, taxes);

            _productRepository.Store(product);
            await _unitOfWork.Save();

            return await Ok(DomainOperationResult.Create(product.UId));
        }
    }
}
