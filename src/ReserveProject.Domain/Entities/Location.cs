using ReserveProject.Domain.Entities.Shared;

namespace ReserveProject.Domain
{
    public class Location : BaseEntity
    {
        public string Name { get; set; }
        public string Longtitude { get; set; }
        public string Latitude { get; set; }
    }
}