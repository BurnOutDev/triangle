using ReserveProject.Domain.Enums;
using ReserveProject.Shared.ApplicationInfrastructure;
using System;
using System.Collections.Generic;
using System.Text;

namespace ReserveProject.Domain.Aggregates.BankAccountAggregate.Commands
{
    public class DeleteBankAccountCommand : ICommand<CommandExecutionResult>
    {
        public Guid UId { get; set; }
    }
}
