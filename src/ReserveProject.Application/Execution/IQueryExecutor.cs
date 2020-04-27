using System.Threading.Tasks;
using ReserveProject.Shared.ApplicationInfrastructure;

namespace ReserveProject.Application.Execution
{
    public interface IQueryExecutor
    {
        Task<QueryExecutionResult<TResult>> Execute<TResult>(IQuery<QueryExecutionResult<TResult>> query);
    }
}