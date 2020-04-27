using ReserveProject.Application.Infrastructure;
using ReserveProject.Domain.Aggregates.InvoiceAggregate;
using ReserveProject.Domain.Aggregates.InvoiceAggregate.Commands;
using ReserveProject.Domain.Aggregates.PartyAggregate;
using ReserveProject.Domain.Aggregates.PaymentTermAggregate;
using ReserveProject.Domain.Aggregates.SalesPersonAggregate;
using ReserveProject.Infrastructure.Database;
using ReserveProject.Shared.ApplicationInfrastructure;
using System.Threading;
using System.Threading.Tasks;
using ReserveProject.Domain.DTOs.Invoice;
using ReserveProject.Domain.Aggregates.ProductAggregate;

namespace ReserveProject.Application.CommandHandlers.CustomerCommandHandler
{
    public class UpdateInvoiceCommandHandler : CommandHandler<UpdateInvoiceCommand>
    {
        private readonly IUnitOfWork _unitOfWork;

        public UpdateInvoiceCommandHandler(IUnitOfWork unitOfWork,
                                            PrimeDbContext invoicingDbContext) : base(invoicingDbContext)
        {
            _unitOfWork = unitOfWork;
        }

        public async override Task<CommandExecutionResult> Handle(UpdateInvoiceCommand request, CancellationToken cancellationToken)
        {
            var invoice = Entity<Invoice>(request.UId);

            var customerId = ExistingEntityId<Party>(request.CustomerUId);
            var paymentTermId = ExistingEntityId<PaymentTerm>(request.PaymentTermUId);
            var salesPersonId = ExistingEntityId<SalesPerson>(request.SalesPersonUId);

            invoice.Update(customerId, paymentTermId, request.StartDate, salesPersonId);
            await _unitOfWork.Save();

            return await Ok(DomainOperationResult.Update(invoice.UId));
        }
    }

    public class AddInvoiceLineToInvoiceCommandHandler : CommandHandler<AddInvoiceLineToInvoiceCommand>
    {
        private readonly IUnitOfWork _unitOfWork;

        public AddInvoiceLineToInvoiceCommandHandler(IUnitOfWork unitOfWork,
                                            PrimeDbContext invoicingDbContext) : base(invoicingDbContext)
        {
            _unitOfWork = unitOfWork;
        }

        public async override Task<CommandExecutionResult> Handle(AddInvoiceLineToInvoiceCommand request, CancellationToken cancellationToken)
        {
            var invoice = Entity<Invoice>(request.UId);
            var product = Entity<Product>(request.InvoiceLine.ProductUId);

            var invoiceLine = new InvoiceLineDTO()
            {
                Product = product,
                Description = request.InvoiceLine.Description,
                Price = request.InvoiceLine.Price,
                Quantity = request.InvoiceLine.Quantity
            };

            invoice.AddInvoiceLine(invoiceLine);
            await _unitOfWork.Save();

            return await Ok(DomainOperationResult.Update(invoice.UId));
        }
    }

    public class DeleteInvoiceLineFromInvoiceCommandHandler : CommandHandler<DeleteInvoiceLineFromInvoiceCommand>
    {
        private readonly IUnitOfWork _unitOfWork;

        public DeleteInvoiceLineFromInvoiceCommandHandler(IUnitOfWork unitOfWork,
                                            PrimeDbContext invoicingDbContext) : base(invoicingDbContext)
        {
            _unitOfWork = unitOfWork;
        }

        public async override Task<CommandExecutionResult> Handle(DeleteInvoiceLineFromInvoiceCommand request, CancellationToken cancellationToken)
        {
            var invoice = Entity<Invoice>(request.UId);
            var invoiceLineId = ExistingEntityId<InvoiceLine>(request.InvoiceLineUId);

            invoice.DeleteInvoiceLine(invoiceLineId);
            await _unitOfWork.Save();

            return await Ok(DomainOperationResult.Update(invoice.UId));
        }
    }

}
