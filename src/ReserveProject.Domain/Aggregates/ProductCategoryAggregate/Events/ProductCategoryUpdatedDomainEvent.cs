using System;
using ReserveProject.Domain.Enums;
using ReserveProject.Shared.DomainInfrastructure;

namespace ReserveProject.Domain.Aggregates.CustomerAggregate.Events
{
    public class ProductCategoryUpdatedDomainEvent : DomainEvent
    {
        public string Name { get; set; }
        public int? ParentId { get; set; }

        public ProductCategoryUpdatedDomainEvent(Guid uId, string name, int? parentId)
        {
            UId = uId;
            Name = name;
            ParentId = parentId;
        }
    }
}