using Microsoft.Extensions.Configuration;
using ReserveProject.Domain.Aggregates.CustomerAggregate;
using ReserveProject.Domain.Aggregates.CustomerAggregate.Commands;
using ReserveProject.Infrastructure.Database;
using ReserveProject.Infrastructure.Repositories.Abstractions;
using ReserveProject.Shared.ApplicationInfrastructure;
using System.Threading;
using System.Threading.Tasks;
using ReserveProject.Application.Infrastructure;

namespace ReserveProject.Application.CommandHandlers.CustomerCommandHandler
{
    public class CreateCustomerCommandHandler : CommandHandler<CreateCustomerCommand>
    {
        private readonly ICustomerRepository _customerRepository;
        private readonly IUnitOfWork _unitOfWork;

        public CreateCustomerCommandHandler(PrimeDbContext invoicingDbContext,
                                            ICustomerRepository customerRepository,
                                            IUnitOfWork unitOfWork):base(invoicingDbContext)
        {
            _customerRepository = customerRepository;
            _unitOfWork = unitOfWork;
        }


        public async override Task<CommandExecutionResult> Handle(CreateCustomerCommand request, CancellationToken cancellationToken)
        {
            var customer = Customer.Create(request.Name);

            _customerRepository.Store(customer);
            await _unitOfWork.Save();

            return await Ok(DomainOperationResult.Create(customer.UId));
        }
    }
}
