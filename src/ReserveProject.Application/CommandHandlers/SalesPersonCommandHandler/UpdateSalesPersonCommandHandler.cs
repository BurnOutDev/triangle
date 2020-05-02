using ReserveProject.Application.Infrastructure;
using ReserveProject.Domain.Aggregates.SalesPersonAggregate;
using ReserveProject.Domain.Aggregates.SalesPersonAggregate.Commands;
using ReserveProject.Infrastructure.Database;
using ReserveProject.Shared.ApplicationInfrastructure;
using System.Threading;
using System.Threading.Tasks;

namespace ReserveProject.Application.CommandHandlers.CustomerCommandHandler
{
    public class UpdateSalesPersonCommandHandler : CommandHandler<UpdateSalesPersonCommand>
    {
        private readonly IUnitOfWork _unitOfWork;

        public UpdateSalesPersonCommandHandler(IUnitOfWork unitOfWork,
                                            PrimeDbContext invoicingDbContext) : base(invoicingDbContext)
        {
            _unitOfWork = unitOfWork;
        }

        public async override Task<CommandExecutionResult> Handle(UpdateSalesPersonCommand request, CancellationToken cancellationToken)
        {
            var salesPerson = Entity<SalesPerson>(request.UId);

            salesPerson.Update(request.Name, request.Email, request.Phone, request.Mobile);
            await _unitOfWork.Save();

            return await Ok(DomainOperationResult.Update(salesPerson.UId));
        }
    }
}
