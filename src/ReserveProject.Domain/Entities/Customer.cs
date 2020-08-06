using ReserveProject.Domain.Entities;
using ReserveProject.Domain.Entities.Shared;
using System;
using System.Collections.Generic;

namespace ReserveProject.Domain
{
    public class Customer : BaseEntity
    {
        public string IdentityUserId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Gender { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public DateTime BithDate { get; set; }
        public bool IsActivated { get; set; }
        public string FacebookId { get; set; }
        public string Avatar { get; set; }

        public string FullName
        {
            get
            {
                return $"{FirstName} {LastName}";
            }
        }

        public virtual ICollection<CustomerFavoriteRestaurants> FavoriteRestaurants { get; set; }
    }
}