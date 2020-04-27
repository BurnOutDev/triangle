using ReserveProject.Infrastructure.Database;
using ReserveProject.Infrastructure.Repositories.Abstractions;
using ReserveProject.Shared.ApplicationInfrastructure;
using System.Threading;
using System.Threading.Tasks;
using ReserveProject.Application.Infrastructure;
using ReserveProject.Domain.Aggregates.InvoiceAggregate;
using ReserveProject.Domain.Aggregates.InvoiceAggregate.Commands;
using ReserveProject.Application.Services;
using ReserveProject.Domain.Aggregates.PartyAggregate;
using ReserveProject.Domain.Aggregates.PaymentTermAggregate;
using ReserveProject.Domain.Aggregates.SalesPersonAggregate;
using System.Linq;
using ReserveProject.Domain.DTOs.Invoice;
using System.Collections.Generic;
using ReserveProject.Domain.Aggregates.ProductAggregate;

namespace ReserveProject.Application.CommandHandlers.CustomerCommandHandler
{
    public class CreateInvoiceCommandHandler : CommandHandler<CreateInvoiceCommand>
    {
        private readonly IInvoiceRepository _invoiceRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly ProductExtractorService productExtractorService;
        public CreateInvoiceCommandHandler(PrimeDbContext invoicingDbContext,
                                            IInvoiceRepository invoiceRepository,
                                            IProductRepository productRepository,
                                            IUnitOfWork unitOfWork) : base(invoicingDbContext)
        {
            _invoiceRepository = invoiceRepository;
            _unitOfWork = unitOfWork;
            productExtractorService = new ProductExtractorService(productRepository);
        }

        public async override Task<CommandExecutionResult> Handle(CreateInvoiceCommand request, CancellationToken cancellationToken)
        {
            var customerId = ExistingEntityId<Party>(request.CustomerUId);
            var paymentTerm = Entity<PaymentTerm>(request.PaymentTermUId);
            var salesPersonId = ExistingEntityId<SalesPerson>(request.SalesPersonUId);

            var products = productExtractorService.Extract(request.InvoiceLines.Select(x => x.ProductUId));

            var invoiceLines = new List<InvoiceLineDTO>();
            foreach (var lineCommand in request.InvoiceLines)
            {
                invoiceLines.Add(new InvoiceLineDTO()
                {
                    Product= products.SingleOrDefault(x => x.UId == lineCommand.ProductUId),
                    Description = lineCommand.Description,
                    Price = lineCommand.Price,
                    Quantity = lineCommand.Quantity
                });
            }

            var invoice = Invoice.Create(request.InvoiceNumber, customerId, paymentTerm, request.StartDate, salesPersonId, invoiceLines);
            _invoiceRepository.Store(invoice);
            await _unitOfWork.Save();

            return await Ok(DomainOperationResult.Create(invoice.UId));
        }
    }
}
