using System.Collections.Generic;
using System.Linq;

namespace ReserveProject.Shared.ApplicationInfrastructure
{
    public class QueryExecutionResult<T>
    {
        public bool Success { get; set; }
        public IEnumerable<Error> Errors { get; set; }
        public T Data { get; set; }


        public static QueryExecutionResult<T> WithError(params KeyValuePair<int, string>[] errors)
        {
            return new QueryExecutionResult<T>()
            {
                Success = false,
                Errors = errors.ToList().Select(x => new Error() { Code = x.Key, Message = x.Value })
            };
        }
    }
}