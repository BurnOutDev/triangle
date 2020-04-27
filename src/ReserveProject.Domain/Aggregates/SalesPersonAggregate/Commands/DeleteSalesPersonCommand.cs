﻿using ReserveProject.Domain.Enums;
using ReserveProject.Shared.ApplicationInfrastructure;
using System;
using System.Collections.Generic;
using System.Text;

namespace ReserveProject.Domain.Aggregates.SalesPersonAggregate.Commands
{
    public class DeleteSalesPersonCommand : ICommand<CommandExecutionResult>
    {
        public Guid UId { get; set; }
    }
}