using ReserveProject.Infrastructure.Database;
using ReserveProject.Infrastructure.Repositories.Abstractions;
using ReserveProject.Shared.ApplicationInfrastructure;
using System.Threading;
using System.Threading.Tasks;
using ReserveProject.Application.Infrastructure;
using ReserveProject.Domain.Aggregates.SalesPersonAggregate;
using ReserveProject.Domain.Aggregates.SalesPersonAggregate.Commands;

namespace ReserveProject.Application.CommandHandlers.CustomerCommandHandler
{
    public class CreateSalesPersonCommandHandler : CommandHandler<CreateSalesPersonCommand>
    {
        private readonly ISalesPersonRepository _salesPersonRepository;
        private readonly IUnitOfWork _unitOfWork;

        public CreateSalesPersonCommandHandler(PrimeDbContext invoicingDbContext,
                                            ISalesPersonRepository salesPersonRepository,
                                            IUnitOfWork unitOfWork) : base(invoicingDbContext)
        {
            _salesPersonRepository = salesPersonRepository;
            _unitOfWork = unitOfWork;
        }


        public async override Task<CommandExecutionResult> Handle(CreateSalesPersonCommand request, CancellationToken cancellationToken)
        {
            var salesPerson = SalesPerson.Create(request.Name, request.Email, request.Phone, request.Mobile);

            _salesPersonRepository.Store(salesPerson);
            await _unitOfWork.Save();

            return await Ok(DomainOperationResult.Create(salesPerson.UId));
        }
    }
}
