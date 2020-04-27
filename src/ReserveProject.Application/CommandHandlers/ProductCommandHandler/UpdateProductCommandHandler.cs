using ReserveProject.Application.Infrastructure;
using ReserveProject.Domain.Aggregates.ProductAggregate;
using ReserveProject.Domain.Aggregates.ProductAggregate.Commands;
using ReserveProject.Domain.Aggregates.ProductCategoryAggregate;
using ReserveProject.Domain.Aggregates.TaxAggregate;
using ReserveProject.Infrastructure.Database;
using ReserveProject.Shared.ApplicationInfrastructure;
using System.Threading;
using System.Threading.Tasks;

namespace ReserveProject.Application.CommandHandlers.CustomerCommandHandler
{
    public class UpdateProductCommandHandler : CommandHandler<UpdateProductCommand>
    {
        private readonly IUnitOfWork _unitOfWork;

        public UpdateProductCommandHandler(IUnitOfWork unitOfWork,
                                            PrimeDbContext invoicingDbContext) : base(invoicingDbContext)
        {
            _unitOfWork = unitOfWork;
        }

        public async override Task<CommandExecutionResult> Handle(UpdateProductCommand request, CancellationToken cancellationToken)
        {
            var product = Entity<Product>(request.UId);
            var categoryId = ExistingEntityId<ProductCategory>(request.CategoryUId);

            product.Update(request.Name, request.Role, request.Type, request.BarCode, categoryId, request.SalesPrice, request.Cost);
            await _unitOfWork.Save();

            return await Ok(DomainOperationResult.Update(product.UId));
        }
    }

    public class AddTaxToProductCommandHandler : CommandHandler<AddTaxToProductCommand>
    {
        private readonly IUnitOfWork _unitOfWork;

        public AddTaxToProductCommandHandler(IUnitOfWork unitOfWork,
                                            PrimeDbContext invoicingDbContext) : base(invoicingDbContext)
        {
            _unitOfWork = unitOfWork;
        }

        public async override Task<CommandExecutionResult> Handle(AddTaxToProductCommand request, CancellationToken cancellationToken)
        {
            var product = Entity<Product>(request.UId);
            var taxId = ExistingEntityId<Tax>(request.TaxUId);

            product.AddTax(taxId);
            await _unitOfWork.Save();

            return await Ok(DomainOperationResult.Update(product.UId));
        }
    }

    public class DeleteTaxFromProductCommandHandler : CommandHandler<DeleteTaxFromProductCommand>
    {
        private readonly IUnitOfWork _unitOfWork;

        public DeleteTaxFromProductCommandHandler(IUnitOfWork unitOfWork,
                                            PrimeDbContext invoicingDbContext) : base(invoicingDbContext)
        {
            _unitOfWork = unitOfWork;
        }

        public async override Task<CommandExecutionResult> Handle(DeleteTaxFromProductCommand request, CancellationToken cancellationToken)
        {
            var product = Entity<Product>(request.UId);
            var taxId = ExistingEntityId<Tax>(request.TaxUId);

            product.DeleteTax(taxId);
            await _unitOfWork.Save();

            return await Ok(DomainOperationResult.Update(product.UId));
        }
    }

}
