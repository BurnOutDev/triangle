using ReserveProject.Domain.Enums;
using ReserveProject.Shared.ApplicationInfrastructure;
using System;
using System.Collections.Generic;
using System.Text;

namespace ReserveProject.Domain.Aggregates.TaxAggregate.Commands
{
    public class CreateTaxCommand : ICommand<CommandExecutionResult>
    {
        public string Name { get; set; }
        public TaxScope Scope { get; set; }
        public TaxComputation Computation { get; set; }
        public decimal Value { get; set; }
    }
}
