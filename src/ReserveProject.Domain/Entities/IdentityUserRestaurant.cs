using ReserveProject.Domain.Entities.Shared;
using System;

namespace ReserveProject.Domain
{
    public class IdentityUserRestaurant : BaseEntity
    {
        public string IdentityUserId { get; set; }
        public virtual Restaurant Restaurant { get; set; }
    }
}