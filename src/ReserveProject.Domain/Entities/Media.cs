using ReserveProject.Domain.Entities.Shared;

namespace ReserveProject.Domain
{
    public class Media : BaseEntity
    {
        public string Name { get; set; }
        public string Url { get; set; }
        public string Format { get; set; }
    }
}