using ReserveProject.Domain.Enums;
using ReserveProject.Shared.ApplicationInfrastructure;
using System;
using System.Collections.Generic;
using System.Text;

namespace ReserveProject.Application.Queries.ProductCategoryQueries
{
    public class ProductCategoryDetailsQuery : IQuery<QueryExecutionResult<ProductCategoryDetailsQueryResult>>
    {
        public Guid UId { get; set; }
    }

    public class ProductCategoryDetailsQueryResult
    {
        public Guid UId { get; set; }
        public string Name { get; set; }
        public Guid? ParentUId { get; set; }
        public string Parent { get; set; }
    }
}
