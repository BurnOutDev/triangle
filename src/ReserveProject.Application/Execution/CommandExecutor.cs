using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using MediatR;
using ReserveProject.Shared.Exceptions;
using ReserveProject.Domain.Exceptions.Abstract;
using ReserveProject.Infrastructure.Database;
using ReserveProject.Infrastructure.Repositories.Abstractions;
using ReserveProject.Shared.ApplicationInfrastructure;
using ReserveProject.Shared.Log;

namespace ReserveProject.Application.Execution
{
    public class CommandExecutor : ICommandExecutor
    {
        private readonly IMediator _mediator;
        private readonly ILoggerRepository _loggerRepository;

        public CommandExecutor(IMediator mediator, ILoggerRepository loggerRepository)
        {
            _mediator = mediator;
            _loggerRepository = loggerRepository;
        }

        public async Task<CommandExecutionResult> Execute(ICommand<CommandExecutionResult> command)
        {
            try
            {
                return await _mediator.Send(command);
            }
            catch (DomainException ex)
            {
                LogException(ex, ExceptionLogType.DomainException);
                return CommandExecutionResult.WithError(new KeyValuePair<int, string>(ex.ErrorCode, ex.Message));
            }

            catch (ApplicationExcepiton ex)
            {
                LogException(ex, ExceptionLogType.ApplicationException);
                return CommandExecutionResult.WithError(new KeyValuePair<int, string>(ex.ErrorCode, ex.Message));
            }

            catch (Exception ex)
            {
                LogException(ex, ExceptionLogType.SystemException);
                return CommandExecutionResult.WithError(new KeyValuePair<int, string>(0, ex.Message));

            }
        }

        private void LogException(Exception exception, ExceptionLogType exceptionLogType)
        {
            _loggerRepository.LogException(new ExceptionLog
            {
                LogDate = DateTimeOffset.Now,
                LogType = exceptionLogType,
                Message = exception.Message
            });
        }
    }
}