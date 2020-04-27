using System.Collections.Generic;

namespace ReserveProject.Shared.DomainInfrastructure
{
    public interface IHasDomainEvents
    {
        IReadOnlyList<DomainEvent> UncommittedChanges();
        void MarkChangesAsCommitted();
        void Raise(DomainEvent evnt);
    }
}