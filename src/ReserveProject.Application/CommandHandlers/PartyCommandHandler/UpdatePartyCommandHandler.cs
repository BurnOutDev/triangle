using ReserveProject.Application.Infrastructure;
using ReserveProject.Domain.Aggregates.PartyAggregate;
using ReserveProject.Domain.Aggregates.PartyAggregate.Commands;
using ReserveProject.Domain.Aggregates.BankAccountAggregate;
using ReserveProject.Infrastructure.Database;
using ReserveProject.Shared.ApplicationInfrastructure;
using System.Threading;
using System.Threading.Tasks;
using ReserveProject.Domain.Aggregates.Location;

namespace ReserveProject.Application.CommandHandlers.CustomerCommandHandler
{
    public class UpdatePartyCommandHandler : CommandHandler<UpdatePartyCommand>
    {
        private readonly IUnitOfWork _unitOfWork;

        public UpdatePartyCommandHandler(IUnitOfWork unitOfWork,
                                            PrimeDbContext invoicingDbContext) : base(invoicingDbContext)
        {
            _unitOfWork = unitOfWork;
        }

        public async override Task<CommandExecutionResult> Handle(UpdatePartyCommand request, CancellationToken cancellationToken)
        {
            var party = Entity<Party>(request.UId);
            var cityId = ExistingEntityId<City>(request.CityUId);

            party.Update(request.Name, request.Type, request.Street, request.StreetDetails,
                request.Role, cityId, request.TaxCode, request.Phone, request.Mobile, request.Email, request.Language);
            await _unitOfWork.Save();

            return await Ok(DomainOperationResult.Update(party.UId));
        }
    }

    public class AddBankAccountToPartyCommandHandler : CommandHandler<AddBankAccountToPartyCommand>
    {
        private readonly IUnitOfWork _unitOfWork;

        public AddBankAccountToPartyCommandHandler(IUnitOfWork unitOfWork,
                                            PrimeDbContext invoicingDbContext) : base(invoicingDbContext)
        {
            _unitOfWork = unitOfWork;
        }

        public async override Task<CommandExecutionResult> Handle(AddBankAccountToPartyCommand request, CancellationToken cancellationToken)
        {
            var party = Entity<Party>(request.UId);
            var bankAccount = Entity<BankAccount>(request.BankAccountUId);

            party.AddBankAccount(bankAccount);
            await _unitOfWork.Save();

            return await Ok(DomainOperationResult.Update(party.UId));
        }
    }

    public class DeleteBankAccountFromPartyCommandHandler : CommandHandler<DeleteBankAccountFromPartyCommand>
    {
        private readonly IUnitOfWork _unitOfWork;

        public DeleteBankAccountFromPartyCommandHandler(IUnitOfWork unitOfWork,
                                            PrimeDbContext invoicingDbContext) : base(invoicingDbContext)
        {
            _unitOfWork = unitOfWork;
        }

        public async override Task<CommandExecutionResult> Handle(DeleteBankAccountFromPartyCommand request, CancellationToken cancellationToken)
        {
            var party = Entity<Party>(request.UId);
            var bankAccount = Entity<BankAccount>(request.BankAccountUId);

            party.DeleteBankAccount(bankAccount);
            await _unitOfWork.Save();

            return await Ok(DomainOperationResult.Update(party.UId));
        }
    }

}
