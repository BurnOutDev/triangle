using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using ReserveProject.Infrastructure.Database;
using ReserveProject.Shared.ApplicationInfrastructure;
using ReserveProject.Application.Infrastructure;

namespace ReserveProject.Application.Infrastructure
{
    public abstract class QueryHandler<TRequest, TResponse> : ApplicationBase, IRequestHandler<TRequest, QueryExecutionResult<TResponse>>
        where TRequest : IRequest<QueryExecutionResult<TResponse>>
    {
        public QueryHandler(PrimeDbContext invoicingDbContext) : base(invoicingDbContext)
        {

        }
        public QueryHandler()
        {

        }
        public abstract Task<QueryExecutionResult<TResponse>> Handle(TRequest request,
            CancellationToken cancellationToken);

        protected Task<QueryExecutionResult<TResponse>> Ok(TResponse data)
        {
            var result = new QueryExecutionResult<TResponse>
            {
                Data = data,
                Success = true
            };
            return Task.FromResult(result);
        }


        protected Task<QueryExecutionResult<IEnumerable<TResponse>>> Ok(List<TResponse> data)
        {
            var result = new QueryExecutionResult<IEnumerable<TResponse>>
            {
                Data = data,
                Success = true
            };
            return Task.FromResult(result);
        }

        protected Task<QueryExecutionResult<TResponse>> Fail(params string[] errorMessages)
        {
            var queryExecutionResult = new QueryExecutionResult<TResponse>
            {
                Success = false,
                Errors = errorMessages.ToList().Select(x => new Error { Code = 0, Message = x })
            };
            return Task.FromResult(queryExecutionResult);
        }
    }
}