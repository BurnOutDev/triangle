using ReserveProject.Shared.ApplicationInfrastructure;

namespace ReserveProject.Domain.Aggregates.CurrencyAggregate.Commands
{
    public class CreateCurrencyCommand : ICommand<CommandExecutionResult>
    {
        public string Name { get; set; }
        public string Code { get; set; }
        public string Symbol { get; set; }
    }
}
