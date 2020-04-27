using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using ReserveProject.Domain.Enums;
using ReserveProject.Domain.Exceptions.Abstract;
using ReserveProject.Domain.Shared.EventDTOs;
using ReserveProject.Shared.Date;
using ReserveProject.Shared.DomainInfrastructure;

namespace ReserveProject.Domain.Shared.Abstract
{
    public abstract class BaseEntity : ICreateDateTrackedEntity, IChangeDateTrackedEntity, IBaseEntity,
        IHasDomainEvents, IHasSecondaryId
    {

        private IList<DomainEvent> Events { get; } = new List<DomainEvent>();

        public EntityId EntityId => new EntityId(Id, UId);

        public int Id { get; set; }

        public EntityStatus EntityStatus { get; protected set; }

        public DateTimeOffset LastChangeDate { get; set; }

        public DateTimeOffset CreateDate { get; set; }
              

        IReadOnlyList<DomainEvent> IHasDomainEvents.UncommittedChanges()
        {
            return new ReadOnlyCollection<DomainEvent>(Events);
        }

        void IHasDomainEvents.MarkChangesAsCommitted()
        {
            Events.Clear();
        }

        void IHasDomainEvents.Raise(DomainEvent evnt)
        {
            Events.Add(evnt);
        }

        public Guid UId
        {
            get; set;
        } = Guid.NewGuid();

        public virtual void Delete()
        {
            EntityStatus = EntityStatus.Deleted;
        }

        public virtual void Activate()
        {
            EntityStatus = EntityStatus.Active;
        }

        public bool Active()
        {
            return EntityStatus == EntityStatus.Active;
        }

        public void ThrowDomainException(string message)
        {
            throw new DomainException(message);
        }

        public void ThrowDomainException(string message, int errorCode)
        {
            throw new DomainException(message, errorCode);
        }

        protected void Raise(DomainEvent evnt)
        {
            evnt.AggregateRootId = Id;
            evnt.EventId = evnt.EventId;
            evnt.OccuredOn = SystemDate.Now;
            evnt.EventType = evnt.GetType().Name;
            evnt.UId = UId;
            (this as IHasDomainEvents).Raise(evnt);
        }
    }
}