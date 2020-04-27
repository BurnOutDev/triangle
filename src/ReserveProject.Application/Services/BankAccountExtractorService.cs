using ReserveProject.Domain.Aggregates.BankAccountAggregate;
using ReserveProject.Infrastructure.Repositories.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ReserveProject.Application.Services
{
    public class BankAccountExtractorService
    {
        private readonly IBankAccountRepository _bankAccountRepository;

        public BankAccountExtractorService(IBankAccountRepository bankAccountRepository)
        {
            _bankAccountRepository = bankAccountRepository;
        }

        public IEnumerable<BankAccount> Extract(IEnumerable<Guid> bankAccountUIds)
        {
            var bankAccountes = _bankAccountRepository.Query(x => bankAccountUIds.Contains(x.UId)).ToList();
            var notFound = bankAccountUIds.Except(bankAccountes.Select(x => x.UId)).Any();
            if (notFound) throw new ApplicationException("specified bank account not found");

            return bankAccountes;

        }

    }
}
