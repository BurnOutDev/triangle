using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using ReserveProject.Infrastructure.Database;
using ReserveProject.Infrastructure.EventDispatching;
using ReserveProject.Shared.DomainInfrastructure;
using ReserveProject.Shared.Logging;
using ReserveProject.Shared.Serialization;

namespace ReserveProject.Application.Services
{
    public class AsynchronousEventProcessor
    {
        private static readonly SemaphoreSlim SemaphoreSlim = new SemaphoreSlim(1, 1);
        private readonly IMediator _mediator;
        private readonly PrimeDbContext _invoicingDbContext;
        private readonly TransactionalDomainEventDispatcher _transactionalDomainEventDispatcher;
        private readonly IUnitOfWork _unitOfWork;

        public AsynchronousEventProcessor(PrimeDbContext invoicingDbContext,
            TransactionalDomainEventDispatcher transactionalDomainEventDispatcher,
            IMediator mediator,
            IUnitOfWork unitOfWork)
        {
            _invoicingDbContext = invoicingDbContext;
            _transactionalDomainEventDispatcher = transactionalDomainEventDispatcher;
            _mediator = mediator;
            _unitOfWork = unitOfWork;
        }

        private async Task ProcessEvents(List<Event> events)
        {
            await SemaphoreSlim.WaitAsync();

            var serilizedEvent = events.Select(x => Serializer.As<DomainEvent>(x.Data)).ToList();
            await _transactionalDomainEventDispatcher.Dispatch(serilizedEvent, _mediator);
            events.ForEach(x => x.MarkAsProcessed());
            await _unitOfWork.Save();

            SemaphoreSlim.Release();
        }

        public List<Event> FetchNewEvents()
        {
            var listOfEvents = _invoicingDbContext.Set<Event>()
                .Where(x => !x.Processed())
                .ToList();
            return listOfEvents;
        }

        public async Task Process()
        {
            await ProcessEvents(FetchNewEvents());
        }
    }
}