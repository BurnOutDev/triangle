using System;

namespace ReserveProject.Domain.Shared.EventDTOs
{
    public class EntityId
    {
        public EntityId(int id, Guid secondaryId)
        {
            Id = id;
            SecondaryId = secondaryId;
        }

        public int Id { get; }
        public Guid SecondaryId { get; }
    }
}