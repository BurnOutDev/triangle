using System.Threading.Tasks;
using ReserveProject.Shared.ApplicationInfrastructure;

namespace ReserveProject.Application.Execution
{
    public interface ICommandExecutor
    {
        Task<CommandExecutionResult> Execute(ICommand<CommandExecutionResult> command);
    }
}