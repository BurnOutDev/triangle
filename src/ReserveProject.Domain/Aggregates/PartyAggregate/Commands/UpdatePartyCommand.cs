using ReserveProject.Domain.Enums;
using ReserveProject.Shared.ApplicationInfrastructure;
using System;
using System.Collections.Generic;
using System.Text;

namespace ReserveProject.Domain.Aggregates.PartyAggregate.Commands
{
    public class UpdatePartyCommand : ICommand<CommandExecutionResult>
    {
        public Guid UId { get; set; }
        public string Name { get; set; }
        public PartyType Type { get; set; }
        public string Street { get; set; }
        public string StreetDetails { get; set; }
        public Guid CityUId { get; set; }
        public string TaxCode { get; set; }
        public string Phone { get; set; }
        public string Mobile { get; set; }
        public string Email { get; set; }
        public Language Language { get; set; }
        public PartyRole Role { get; set; }
        public List<Guid> BankAccountUIds { get; set; }
    }

    public class AddBankAccountToPartyCommand : ICommand<CommandExecutionResult>
    {
        public Guid UId { get; set; }
        public Guid BankAccountUId { get; set; }
    }

    public class DeleteBankAccountFromPartyCommand : ICommand<CommandExecutionResult>
    {
        public Guid UId { get; set; }
        public Guid BankAccountUId { get; set; }
    }
}
