using ReserveProject.Domain.Enums;
using ReserveProject.Shared.ApplicationInfrastructure;
using System;
using System.Collections.Generic;
using System.Text;

namespace ReserveProject.Domain.Aggregates.ProductAggregate.Commands
{
    public class CreateProductCommand : ICommand<CommandExecutionResult>
    {
        public string Name { get; set; }
        public ProductRole Role { get; set; }
        public ProductType Type { get; set; }
        public string BarCode { get; set; }
        public decimal SalesPrice { get; set; }
        public decimal Cost { get; set; }
        public virtual Guid CategoryUId { get; set; }
        public virtual Guid[] TaxUIds { get; set; }
    }
}
