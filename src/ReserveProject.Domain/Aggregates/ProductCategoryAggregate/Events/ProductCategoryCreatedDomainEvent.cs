using System;
using ReserveProject.Domain.Enums;
using ReserveProject.Shared.DomainInfrastructure;

namespace ReserveProject.Domain.Aggregates.CustomerAggregate.Events
{
    public class ProductCategoryCreatedDomainEvent : DomainEvent
    {
        public string Name { get; set; }
        public int? ParentId { get; set; }

        public ProductCategoryCreatedDomainEvent(Guid uId, string name, int? parentId)
        {
            UId = uId;
            Name = name;
            ParentId = parentId;
        }
    }
}