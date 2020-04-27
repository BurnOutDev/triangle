using ReserveProject.Domain.Enums;
using ReserveProject.Shared.ApplicationInfrastructure;
using System;
using System.Collections.Generic;
using System.Text;
using static ReserveProject.Domain.Aggregates.InvoiceAggregate.Commands.CreateInvoiceCommand;

namespace ReserveProject.Domain.Aggregates.InvoiceAggregate.Commands
{
    public class UpdateInvoiceCommand : ICommand<CommandExecutionResult>
    {
        public Guid UId { get; set; }
        public Guid CustomerUId { get; set; }
        public Guid PaymentTermUId { get; set; }
        public DateTimeOffset StartDate { get; set; }
        public Guid SalesPersonUId { get; set; }
    }

    public class AddInvoiceLineToInvoiceCommand : ICommand<CommandExecutionResult>
    {
        public Guid UId { get; set; }
        public CreateInvoiceLineCommand InvoiceLine { get; set; }
    }

    public class DeleteInvoiceLineFromInvoiceCommand : ICommand<CommandExecutionResult>
    {
        public Guid UId { get; set; }
        public Guid InvoiceLineUId { get; set; }
    }

    public class ValidateInvoiceCommand : ICommand<CommandExecutionResult>
    {
        public Guid UId { get; set; }
    }
}
