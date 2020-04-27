using ReserveProject.Domain.Enums;
using ReserveProject.Shared.ApplicationInfrastructure;
using System;
using System.Collections.Generic;
using System.Text;

namespace ReserveProject.Application.Queries.ProductQueries
{
    public class ProductDetailsQuery : IQuery<QueryExecutionResult<ProductDetailsQueryResult>>
    {
        public Guid UId { get; set; }
    }

    public class ProductDetailsQueryResult
    {
        public Guid UId { get; set; }
        public string Name { get; set; }
        public ProductRole Role { get; set; }
        public ProductType Type { get; set; }
        public string BarCode { get; set; }
        public Guid CategoryUId { get; set; }
        public decimal SalesPrice { get; set; }
        public decimal Cost { get; set; }
        public string Category { get; set; }
        public virtual IEnumerable<TaxResult> Taxes { get; set; }

        public class TaxResult
        {
            public Guid UId { get; set; }
            public string Name { get; set; }
        }
    }
}
