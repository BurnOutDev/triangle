using ReserveProject.Domain.Entities.Shared;

namespace ReserveProject.Domain
{
    public class Category : BaseEntity
    {
        public string Name { get; set; }
        public string Icon { get; set; }
    }
}
