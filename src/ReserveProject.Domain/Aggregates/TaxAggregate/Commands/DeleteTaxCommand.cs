using ReserveProject.Domain.Enums;
using ReserveProject.Shared.ApplicationInfrastructure;
using System;
using System.Collections.Generic;
using System.Text;

namespace ReserveProject.Domain.Aggregates.TaxAggregate.Commands
{
    public class DeleteTaxCommand : ICommand<CommandExecutionResult>
    {
        public Guid UId { get; set; }
    }
}
