using ReserveProject.Domain.Aggregates.CustomerAggregate.Events;
using ReserveProject.Domain.Aggregates.ProductCategoryAggregate;
using ReserveProject.Domain.Aggregates.TaxAggregate;
using ReserveProject.Domain.Enums;
using ReserveProject.Domain.Exceptions.Abstract;
using ReserveProject.Domain.Shared.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ReserveProject.Domain.Aggregates.ProductAggregate
{
    public class Product : BaseEntity
    {
        public string Name { get; set; }
        public ProductRole Role { get; set; }
        public ProductType Type { get; set; }
        public string BarCode { get; set; }
        public int CategoryId { get; set; }
        public decimal SalesPrice { get; set; }
        public decimal Cost { get; set; }
        public virtual ProductCategory Category { get; set; }
        public virtual List<ProductTax> ProductTaxes { get; set; } = new List<ProductTax>();

        public Product()
        {
        }

        public static Product Create(string name, ProductRole role, ProductType type, string barCode, int categoryId, decimal salesPrice, decimal cost, IEnumerable<Tax> taxes)
        {
            var product = new Product()
            {
                Name = name,
                Role = role,
                Type = type,
                BarCode = barCode,
                CategoryId = categoryId,
                SalesPrice = salesPrice,
                Cost = cost
            };
            product.ProductTaxes = taxes.Select(x => new ProductTax() { Product = product, Tax = x }).ToList();
            product.Raise(new ProductCreatedDomainEvent(product.UId, product.Name, product.Role,
                product.Type, product.BarCode, product.CategoryId, product.SalesPrice, product.Cost, product.ProductTaxes.Select(x => x.TaxId)));

            return product;
        }

        public void Update(string name, ProductRole role, ProductType type, string barCode, int categoryId, decimal salesPrice, decimal cost)
        {
            Name = name;
            Role = role;
            Type = type;
            BarCode = barCode;
            CategoryId = categoryId;
            SalesPrice = salesPrice;
            Cost = cost;

            Raise(new ProductUpdatedDomainEvent(UId, Name, Role, Type, BarCode, CategoryId, SalesPrice, Cost));
        }

        public void AddTax(int taxId)
        {
            if (ProductTaxes.Any(x => x.TaxId == taxId))
                throw new DomainException("Tax is already added to this Product");
            ProductTaxes.Add(new ProductTax()
            {
                ProductId = Id,
                TaxId = taxId
            });

            Raise(new TaxAddedToProductDomainEvent(UId, taxId));
        }

        public void DeleteTax(int taxId)
        {
            var productTax = ProductTaxes.SingleOrDefault(x => x.TaxId == taxId);
            if (productTax == default(ProductTax))
                throw new DomainException("Product doesn't have this tax");
            ProductTaxes.Remove(productTax);

            Raise(new TaxDeletedFromProductDomainEvent(UId, taxId));
        }

        public override void Delete()
        {
            base.Delete();

            Raise(new ProductDeletedDomainEvent(UId));
        }
    }

    public class ProductTax
    {
        public int ProductId { get; set; }
        public virtual Product Product { get; set; }

        public int TaxId { get; set; }
        public virtual Tax Tax { get; set; }
    }
}
