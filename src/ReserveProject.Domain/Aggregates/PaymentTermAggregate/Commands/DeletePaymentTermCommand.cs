using ReserveProject.Domain.Enums;
using ReserveProject.Shared.ApplicationInfrastructure;
using System;
using System.Collections.Generic;
using System.Text;

namespace ReserveProject.Domain.Aggregates.PaymentTermAggregate.Commands
{
    public class DeletePaymentTermCommand : ICommand<CommandExecutionResult>
    {
        public Guid UId { get; set; }
    }
}
