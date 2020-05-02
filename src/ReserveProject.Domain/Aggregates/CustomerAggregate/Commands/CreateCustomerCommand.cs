using ReserveProject.Shared.ApplicationInfrastructure;

namespace ReserveProject.Domain.Aggregates.CustomerAggregate.Commands
{
    public class CreateCustomerCommand : ICommand<CommandExecutionResult>
    {
        public string Name { get; set; }
    }
}