using System;
using System.Collections.Generic;
using System.Text;

namespace ReserveProject.Domain.Queries
{
    public class DropdownQuery
    {
        public Type Entity { get; set; }
    }

    public class DropdownQueryResult
    {
        public Dictionary<int, string> KeyValues { get; set; }
    }
}
