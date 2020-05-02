using ReserveProject.Domain.Aggregates.TaxAggregate;
using ReserveProject.Infrastructure.Repositories.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ReserveProject.Application.Services
{
    public class TaxExtractorService
    {
        private readonly ITaxRepository _taxRepository;

        public TaxExtractorService(ITaxRepository taxRepository)
        {
            _taxRepository = taxRepository;
        }

        public IEnumerable<Tax> Extract(IEnumerable<Guid> taxUIds)
        {
            var taxes = _taxRepository.Query(x => taxUIds.Contains(x.UId)).ToList();
            var notFound = taxUIds.Except(taxes.Select(x => x.UId)).Any();
            if (notFound) throw new ApplicationException("specified service not found");

            return taxes;

        }
    }
}
