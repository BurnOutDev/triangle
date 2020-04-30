using ReserveProject.Domain.Entities.Shared;

namespace ReserveProject.Domain
{
    public class Organization : BaseEntity
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string BusinessID { get; set; }
        public string PhoneNumber { get; set; }
        public string Address { get; set; }
        public string Email { get; set; }
        public virtual Customer Representative { get; set; }
        public bool IsActivated { get; set; }
        public string FacebookId { get; set; }
    }
}