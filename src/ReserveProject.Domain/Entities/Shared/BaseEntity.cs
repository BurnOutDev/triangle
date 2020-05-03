using ReserveProject.Domain.Enums;

namespace ReserveProject.Domain.Entities.Shared
{
    public abstract class BaseEntity
    {
        public int Id { get; set; }
        public EntityStatus EntityStatus { get; set; }
    }
}
