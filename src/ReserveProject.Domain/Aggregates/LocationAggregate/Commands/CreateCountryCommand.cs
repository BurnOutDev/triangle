using System;
using ReserveProject.Shared.ApplicationInfrastructure;

namespace ReserveProject.Domain.Aggregates.Location.Commands
{
    public class CreateCountryCommand : ICommand<CommandExecutionResult>
    {
        public string Name { get; set; }
        public string CountryCode { get; set; }
    }

    public class CreateStateCommand : ICommand<CommandExecutionResult>
    {
        public string Name { get; set; }
        public Guid CountryUId { get; set; }
    }

    public class CreateCityCommand : ICommand<CommandExecutionResult>
    {
        public string Name { get; set; }
        public Guid StateUId { get; set; }
    }

    public class UpdateCountryCommand : ICommand<CommandExecutionResult>
    {
        public Guid UId { get; set; }
        public string Name { get; set; }
        public string CountryCode { get; set; }
    }

    public class UpdateStateCommand : ICommand<CommandExecutionResult>
    {
        public Guid UId { get; set; }
        public string Name { get; set; }
        public Guid CountryUId { get; set; }
    }

    public class UpdateCityCommand : ICommand<CommandExecutionResult>
    {
        public Guid UId { get; set; }
        public string Name { get; set; }
        public Guid StateUId { get; set; }
    }
       
    public class DeleteCountryCommand : ICommand<CommandExecutionResult>
    {
        public Guid UId { get; set; }
    }
       
    public class DeleteStateCommand : ICommand<CommandExecutionResult>
    {
        public Guid UId { get; set; }
    }

    public class DeleteCityCommand : ICommand<CommandExecutionResult>
    {
        public Guid UId { get; set; }
    }
}
