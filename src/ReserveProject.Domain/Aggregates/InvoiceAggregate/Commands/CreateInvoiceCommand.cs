using ReserveProject.Domain.Enums;
using ReserveProject.Shared.ApplicationInfrastructure;
using System;
using System.Collections.Generic;
using System.Text;

namespace ReserveProject.Domain.Aggregates.InvoiceAggregate.Commands
{
    public class CreateInvoiceCommand : ICommand<CommandExecutionResult>
    {
        public string InvoiceNumber { get; set; }
        public Guid CustomerUId { get; set; }
        public Guid PaymentTermUId { get; set; }
        public DateTimeOffset StartDate { get; set; }
        public Guid SalesPersonUId { get; set; }
        public IEnumerable<CreateInvoiceLineCommand> InvoiceLines { get; set; }

        public class CreateInvoiceLineCommand
        {
            public Guid ProductUId { get; set; }
            public string Description { get; set; }
            public int Quantity { get; set; }
            public decimal Price { get; set; }
        }
    }
}
