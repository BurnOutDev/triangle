using ReserveProject.Shared.ApplicationInfrastructure;
using System;
using System.Collections.Generic;
using System.Text;

namespace ReserveProject.Domain.Aggregates.BankAggregate.Commands
{
    public class DeleteBankCommand : ICommand<CommandExecutionResult>
    {
        public Guid UId { get; set; }
    }
}
