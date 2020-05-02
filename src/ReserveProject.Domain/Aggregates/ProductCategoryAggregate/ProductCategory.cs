using ReserveProject.Domain.Aggregates.CustomerAggregate.Events;
using ReserveProject.Domain.Shared.Abstract;
using System;
using System.Collections.Generic;
using System.Text;

namespace ReserveProject.Domain.Aggregates.ProductCategoryAggregate
{
    public class ProductCategory : BaseEntity
    {
        public string Name { get; set; }
        public int? ParentId { get; set; }
        public virtual ProductCategory Parent { get; set; }

        public ProductCategory()
        {
        }

        public static ProductCategory Create(string name, int? parentId)
        {
            var category = new ProductCategory()
            {
                Name = name,
                ParentId = parentId
            };

            category.Raise(new ProductCategoryCreatedDomainEvent(category.UId, category.Name, category.ParentId));
            return category;
        }

        public void Update(string name, int? parentId)
        {
            Name = name;
            ParentId = parentId;

            Raise(new ProductCategoryUpdatedDomainEvent(UId, Name, ParentId));
        }

        public override void Delete()
        {
            base.Delete();

            Raise(new ProductCategoryDeletedDomainEvent(UId));
        }
    }
}
