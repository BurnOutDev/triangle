using ReserveProject.Application.Infrastructure;
using ReserveProject.Domain.Aggregates.CustomerAggregate;
using ReserveProject.Domain.Aggregates.CustomerAggregate.Commands;
using ReserveProject.Infrastructure.Database;
using ReserveProject.Shared.ApplicationInfrastructure;
using System.Threading;
using System.Threading.Tasks;

namespace ReserveProject.Application.CommandHandlers.CustomerCommandHandler
{
    public class UpdateCustomerDetailsCommandHandler : CommandHandler<UpdateCustomerDetailsCommand>
    {
        private readonly IUnitOfWork _unitOfWork;

        public UpdateCustomerDetailsCommandHandler(IUnitOfWork unitOfWork,
                                            PrimeDbContext invoicingDbContext) : base(invoicingDbContext)
        {
            _unitOfWork = unitOfWork;
        }

        public async override Task<CommandExecutionResult> Handle(UpdateCustomerDetailsCommand request, CancellationToken cancellationToken)
        {
            var customer = Entity<Customer>(request.UId);

            customer.Update(request.Name);
            await _unitOfWork.Save();

            return await Ok(DomainOperationResult.CreateEmpty());
        }
    }
}
