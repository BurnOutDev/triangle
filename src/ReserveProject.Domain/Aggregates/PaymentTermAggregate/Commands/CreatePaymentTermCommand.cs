using ReserveProject.Domain.Enums;
using ReserveProject.Shared.ApplicationInfrastructure;
using System;
using System.Collections.Generic;
using System.Text;

namespace ReserveProject.Domain.Aggregates.PaymentTermAggregate.Commands
{
    public class CreatePaymentTermCommand : ICommand<CommandExecutionResult>
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public int DaysCount { get; set; }
    }
}

