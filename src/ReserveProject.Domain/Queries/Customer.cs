using System;
using System.Collections.Generic;
using System.Text;

namespace ReserveProject.Domain.Queries
{
    public class CustomerProfileQueryResult
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Gender { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public DateTime BithDate { get; set; }
        public bool IsActivated { get; set; }
        public string FacebookId { get; set; }
        public string Avatar { get; set; }
    }
}
