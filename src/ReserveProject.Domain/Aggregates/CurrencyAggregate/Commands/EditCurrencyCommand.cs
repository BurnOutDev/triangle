using System;
using ReserveProject.Shared.ApplicationInfrastructure;

namespace ReserveProject.Domain.Aggregates.CurrencyAggregate.Commands
{
    public class EditCurrencyCommand : ICommand<CommandExecutionResult>
    {
        public Guid UId { get; set; }
        public string Name { get; set; }
        public string Code { get; set; }
        public string Symbol { get; set; }
    }
}
