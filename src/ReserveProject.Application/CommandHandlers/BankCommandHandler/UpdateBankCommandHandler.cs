using ReserveProject.Application.Infrastructure;
using ReserveProject.Domain.Aggregates.BankAggregate;
using ReserveProject.Domain.Aggregates.BankAggregate.Commands;
using ReserveProject.Domain.Aggregates.Location;
using ReserveProject.Infrastructure.Database;
using ReserveProject.Shared.ApplicationInfrastructure;
using System.Threading;
using System.Threading.Tasks;

namespace ReserveProject.Application.CommandHandlers.CustomerCommandHandler
{
    public class UpdateBankCommandHandler : CommandHandler<UpdateBankCommand>
    {
        private readonly IUnitOfWork _unitOfWork;

        public UpdateBankCommandHandler(IUnitOfWork unitOfWork,
                                            PrimeDbContext invoicingDbContext) : base(invoicingDbContext)
        {
            _unitOfWork = unitOfWork;
        }

        public async override Task<CommandExecutionResult> Handle(UpdateBankCommand request, CancellationToken cancellationToken)
        {
            var bank = Entity<Bank>(request.UId);
            var cityId = ExistingEntityId<City>(request.CityUId);

            bank.Update(request.Name, request.IdentifierCode, request.Street, request.StreetInDetails, cityId, request.ZipCode, request.IsActive, request.Phone, request.Email);
            await _unitOfWork.Save();

            return await Ok(DomainOperationResult.Update(bank.UId));
        }
    }
}
