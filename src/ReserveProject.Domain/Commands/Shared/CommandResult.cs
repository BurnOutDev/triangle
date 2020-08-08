using System;
using System.Collections.Generic;
using System.Text;

namespace ReserveProject.Domain.Commands.Shared
{
    public abstract class CommandResult
    {
        public bool IsError { get; set; }
        public string[] ErrorMessages { get; set; }
    }
}
