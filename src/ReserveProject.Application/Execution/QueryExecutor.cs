using MediatR;
using ReserveProject.Domain.Exceptions.Abstract;
using ReserveProject.Infrastructure.Repositories.Abstractions;
using ReserveProject.Shared.ApplicationInfrastructure;
using ReserveProject.Shared.Exceptions;
using ReserveProject.Shared.Log;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ReserveProject.Application.Execution
{
    public class QueryExecutor : IQueryExecutor
    {
        private readonly IMediator _mediator;
        private readonly ILoggerRepository loggerRepository;

        public QueryExecutor(IMediator mediator,
            ILoggerRepository loggerRepository)
        {
            _mediator = mediator;
            this.loggerRepository = loggerRepository;
        }

        public async Task<QueryExecutionResult<TResult>> Execute<TResult>(IQuery<QueryExecutionResult<TResult>> query)
        {
            try
            {
                return await _mediator.Send(query);
            }
            catch (DomainException ex)
            {
                return QueryExecutionResult<TResult>.WithError(new KeyValuePair<int, string>(ex.ErrorCode, ex.Message));
            }
            catch (ApplicationExcepiton ex)
            {
                LogException(ex, ExceptionLogType.ApplicationException);
                return QueryExecutionResult<TResult>.WithError(new KeyValuePair<int, string>(ex.ErrorCode, ex.Message));
            }
            catch (Exception ex)
            {
                LogException(ex, ExceptionLogType.SystemException);
                return QueryExecutionResult<TResult>.WithError(new KeyValuePair<int, string>(0, ex.Message));
            }

        }
        private void LogException(Exception exception, ExceptionLogType exceptionLogType)
        {
            loggerRepository.LogException(new ExceptionLog
            {
                LogDate = DateTimeOffset.Now,
                LogType = exceptionLogType,
                Message = exception.Message
            });
        }

        public async Task<TResult> ExecuteForFile<TResult>(IQuery<TResult> query)
        {
            return await _mediator.Send(query);
        }
    }
}