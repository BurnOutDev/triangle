using ReserveProject.Domain.Entities.Shared;
using System;

namespace ReserveProject.Domain
{
    public class Customer : BaseEntity
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Gender { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public DateTime BithDate { get; set; }
        public bool IsActivated { get; set; }
        public string FacebookId { get; set; }
    }
}