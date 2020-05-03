using ReserveProject.Domain.Entities.Shared;

namespace ReserveProject.Domain
{
    public class Promo : BaseEntity
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal DiscountPercent { get; set; }
    }
}

//