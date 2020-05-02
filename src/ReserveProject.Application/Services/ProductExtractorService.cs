using ReserveProject.Domain.Aggregates.ProductAggregate;
using ReserveProject.Infrastructure.Repositories.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ReserveProject.Application.Services
{
    public class ProductExtractorService
    {
        private readonly IProductRepository _productRepository;

        public ProductExtractorService(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public IEnumerable<Product> Extract(IEnumerable<Guid> productUIds)
        {
            var productes = _productRepository.Query(x => productUIds.Contains(x.UId)).ToList();
            var notFound = productUIds.Except(productes.Select(x => x.UId)).Any();
            if (notFound) throw new ApplicationException("specified product not found");

            return productes;
        }

    }
}
