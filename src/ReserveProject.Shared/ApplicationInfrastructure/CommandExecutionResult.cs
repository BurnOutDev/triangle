using System.Collections.Generic;
using System.Linq;

namespace ReserveProject.Shared.ApplicationInfrastructure
{
    public class CommandExecutionResult<T>
    {
        public bool Success { get; set; }
        public IEnumerable<Error> Errors { get; set; }
        public T Data { get; set; }

        public static CommandExecutionResult<T> Default()
        {
            return new CommandExecutionResult<T>();
        }
    }

    public class CommandExecutionResult : CommandExecutionResult<dynamic>
    {
        public new static CommandExecutionResult Default()
        {
            return new CommandExecutionResult();
        }
        public static CommandExecutionResult WithError(params KeyValuePair<int, string>[] errors)
        {
            return new CommandExecutionResult()
            {
                Success = false,
                Errors = errors.ToList().Select(x => new Error() { Code = x.Key, Message = x.Value })
            };
        }

    }
}