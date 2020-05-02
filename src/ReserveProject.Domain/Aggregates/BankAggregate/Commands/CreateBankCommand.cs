using ReserveProject.Shared.ApplicationInfrastructure;
using System;
using System.Collections.Generic;
using System.Text;

namespace ReserveProject.Domain.Aggregates.BankAggregate.Commands
{
    public class CreateBankCommand : ICommand<CommandExecutionResult>
    {
        public string Name { get; set; }
        public string IdentifierCode { get; set; }
        public string Street { get; set; }
        public string StreetInDetails { get; set; }
        public Guid CityUId { get; set; }
        public string ZipCode { get; set; }
        public bool IsActive { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
    }
}
