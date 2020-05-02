using System;
using System.Collections.Generic;
using ReserveProject.Domain.Enums;
using ReserveProject.Shared.DomainInfrastructure;

namespace ReserveProject.Domain.Aggregates.CustomerAggregate.Events
{
    public class ProductUpdatedDomainEvent : DomainEvent
    {
        public string Name { get; set; }
        public ProductRole Role { get; set; }
        public ProductType Type { get; set; }
        public string BarCode { get; set; }
        public int CategoryId { get; set; }
        public decimal SalesPrice { get; set; }
        public decimal Cost { get; set; }

        public ProductUpdatedDomainEvent(Guid uId, string name, ProductRole role, ProductType type, string barCode, int categoryId, decimal salesPrice, decimal cost)
        {
            UId = uId;
            Name = name;
            Role = role;
            Type = type;
            BarCode = barCode;
            CategoryId = categoryId;
            SalesPrice = salesPrice;
            Cost = cost;
        }
    }

    public class TaxAddedToProductDomainEvent : DomainEvent
    {
        public int  TaxId { get; set; }
        public TaxAddedToProductDomainEvent(Guid uId,int taxId)
        {
            UId = uId;
            TaxId = taxId;
        }
    }
    public class TaxDeletedFromProductDomainEvent : DomainEvent
    {
        public int TaxId { get; set; }
        public TaxDeletedFromProductDomainEvent(Guid uId, int taxId)
        {
            UId = uId;
            TaxId = taxId;
        }
    }
}