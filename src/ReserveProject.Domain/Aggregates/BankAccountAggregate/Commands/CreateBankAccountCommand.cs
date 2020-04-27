using ReserveProject.Domain.Enums;
using ReserveProject.Shared.ApplicationInfrastructure;
using System;
using System.Collections.Generic;
using System.Text;

namespace ReserveProject.Domain.Aggregates.BankAccountAggregate.Commands
{
    public class CreateBankAccountCommand : ICommand<CommandExecutionResult>
    {
        public string Name { get; set; }
        public string Number { get; set; }
        public Guid BankUId { get; set; }
    }
}
