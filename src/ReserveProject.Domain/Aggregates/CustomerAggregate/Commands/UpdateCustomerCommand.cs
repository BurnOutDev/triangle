using System;
using ReserveProject.Shared.ApplicationInfrastructure;

namespace ReserveProject.Domain.Aggregates.CustomerAggregate.Commands
{
    public class UpdateCustomerDetailsCommand : ICommand<CommandExecutionResult>
    {
        public Guid UId { get; set; }
        public string Name { get; set; }
    }  
}
