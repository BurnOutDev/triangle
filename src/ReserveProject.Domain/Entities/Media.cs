using ReserveProject.Domain.Entities.Shared;
using ReserveProject.Domain.Enums;

namespace ReserveProject.Domain
{
    public class Media : BaseEntity
    {
        public string Name { get; set; }
        public string Url { get; set; }
        public MediaFormat Format { get; set; }
    }
}