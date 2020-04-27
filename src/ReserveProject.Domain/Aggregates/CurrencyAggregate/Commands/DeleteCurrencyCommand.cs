using System;
using ReserveProject.Shared.ApplicationInfrastructure;

namespace ReserveProject.Domain.Aggregates.CurrencyAggregate.Commands
{
    public class DeleteCurrencyCommand : ICommand<CommandExecutionResult>
    {
        public Guid UId { get; set; }
    }
}
