using ReserveProject.Domain.Enums;
using ReserveProject.Shared.ApplicationInfrastructure;
using System;
using System.Collections.Generic;
using System.Text;

namespace ReserveProject.Domain.Aggregates.ProductCategoryAggregate.Commands
{
    public class CreateProductCategoryCommand : ICommand<CommandExecutionResult>
    {
        public string Name { get; set; }
        public Guid? ParentUId { get; set; }
    }
}
