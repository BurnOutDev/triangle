using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using ReserveProject.Domain.Shared.Abstract;
using ReserveProject.Infrastructure.Database;
using ReserveProject.Shared.ApplicationInfrastructure;
using ReserveProject.Shared.Exceptions;
using MediatR;

namespace ReserveProject.Application.Infrastructure
{
    public abstract class CommandHandler<TRequest> : ApplicationBase, IRequestHandler<TRequest, CommandExecutionResult>
        where TRequest : IRequest<CommandExecutionResult>
    {
        public abstract Task<CommandExecutionResult> Handle(TRequest request, CancellationToken cancellationToken);

        protected Task<CommandExecutionResult> Ok(DomainOperationResult data)
        {
            var result = new CommandExecutionResult
            {
                Data = data,
                Success = true
            };
            return Task.FromResult(result);
        }

        protected Task<CommandExecutionResult> Fail(params string[] errorMessages)
        {
            var commandExecutionResult = new CommandExecutionResult
            {
                Success = false,
                Errors = errorMessages.ToList().Select(x => new Error { Code = 0, Message = x })
            };
            return Task.FromResult(commandExecutionResult);
        }


        public CommandHandler(PrimeDbContext invoicingDbContext) : base(invoicingDbContext)
        {

        }
        public CommandHandler()
        {

        }
    }
    public class ApplicationBase
    {
        private PrimeDbContext _invoicingDbContext;
        protected readonly RepositoryBase RepositoryBase;

        public ApplicationBase()
        {

        }
        public ApplicationBase(PrimeDbContext invoicingDbContext)
        {
            RepositoryBase = new RepositoryBase(invoicingDbContext);
            _invoicingDbContext = invoicingDbContext;
        }

        public T Entity<T>(Guid uId) where T : BaseEntity
        {
            var entity = RepositoryBase.Entity<T>(uId);
            if (entity == default(T))
            {
                var objName = typeof(T).Name;
                throw new ApplicationExcepiton($"{objName} Not Found");
            }

            return entity;
        }

        public int? EntityId<T>(Guid? uId) where T : BaseEntity
        {

            int? id = uId.HasValue ? RepositoryBase.EntityId<T>(uId.Value) : 0;
            return id == 0 ? null : id;

        }

        public int ExistingEntityId<T>(Guid uId) where T : BaseEntity
        {
            var id = EntityId<T>(uId);
            if (!id.HasValue)
            {
                var objName = typeof(T).Name;
                throw new ApplicationExcepiton($"{objName} Not Found");
            }

            return id.Value;
        }

        protected string[] NotFound(params string[] items)
        {
            var errorMessages = new List<string>();
            foreach (var item in items)
            {
                if (!string.IsNullOrEmpty(item))
                {
                    errorMessages.Add($"{item} Not Found");
                }
            }
            return errorMessages.ToArray();
        }
    }
}