using System.Collections.Generic;
using System.Threading.Tasks;
using MediatR;

namespace ReserveProject.Infrastructure.EventDispatching
{
    public interface IEventDispatcher<in TDomainEvent>
    {
        Task Dispatch(IReadOnlyList<TDomainEvent> domainEvents, IMediator dbContext);
    }
}