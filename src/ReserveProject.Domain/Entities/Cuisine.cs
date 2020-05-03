using ReserveProject.Domain.Entities.Shared;

namespace ReserveProject.Domain
{
    public class Cuisine : BaseEntity
    {
        public string Name { get; set; }
        public string Icon { get; set; }
    }
}
