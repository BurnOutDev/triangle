using ReserveProject.Domain.Enums;
using ReserveProject.Shared.ApplicationInfrastructure;
using System;
using System.Collections.Generic;
using System.Text;

namespace ReserveProject.Domain.Aggregates.ProductAggregate.Commands
{
    public class UpdateProductCommand : ICommand<CommandExecutionResult>
    {
        public Guid UId { get; set; }
        public string Name { get; set; }
        public ProductRole Role { get; set; }
        public ProductType Type { get; set; }
        public string BarCode { get; set; }
        public decimal SalesPrice { get; set; }
        public decimal Cost { get; set; }
        public virtual Guid CategoryUId { get; set; }
    }

    public class AddTaxToProductCommand : ICommand<CommandExecutionResult>
    {
        public Guid UId { get; set; }
        public Guid TaxUId { get; set; }
    }

    public class DeleteTaxFromProductCommand : ICommand<CommandExecutionResult>
    {
        public Guid UId { get; set; }
        public Guid TaxUId { get; set; }
    }
}
