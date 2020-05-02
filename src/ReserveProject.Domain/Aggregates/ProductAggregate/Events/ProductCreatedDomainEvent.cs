using System;
using System.Collections.Generic;
using ReserveProject.Domain.Enums;
using ReserveProject.Shared.DomainInfrastructure;

namespace ReserveProject.Domain.Aggregates.CustomerAggregate.Events
{
    public class ProductCreatedDomainEvent : DomainEvent
    {
        public string Name { get; set; }
        public ProductRole Role { get; set; }
        public ProductType Type { get; set; }
        public string BarCode { get; set; }
        public int CategoryId { get; set; }
        public decimal SalesPrice { get; set; }
        public decimal Cost { get; set; }
        public virtual IEnumerable<int> TaxIds { get; set; }

        public ProductCreatedDomainEvent(Guid uId, string name, ProductRole role,ProductType type, string barCode, int categoryId,decimal salesPrice,decimal cost,IEnumerable<int> taxIds)
        {
            UId = uId;
            Name = name;
            Role = role;
            Type = type;
            BarCode = barCode;
            CategoryId = categoryId;
            SalesPrice = salesPrice;
            Cost = cost;
            TaxIds = taxIds;
        }
    }
}