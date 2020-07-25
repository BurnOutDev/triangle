using System;
using System.Collections.Generic;
using System.Text;

namespace ReserveProject.Domain.Queries
{
    public class KeyValuesQuery
    {
        public Type Entity { get; set; }
    }

    public class KeyValuesQueryResult
    {
        public Dictionary<int, string> KeyValues { get; set; }

        public KeyValuesQueryResult(Dictionary<int, string> keyValues)
        {
            KeyValues = keyValues;
        }
    }
}
