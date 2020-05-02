
using ReserveProject.Shared.ApplicationInfrastructure;
using System;

namespace ReserveProject.Domain.Aggregates.CustomerAggregate.Commands
{
    public class DeleteCustomerCommand : ICommand<CommandExecutionResult>
    {
        public Guid UId { get; set; }
    }   
}
