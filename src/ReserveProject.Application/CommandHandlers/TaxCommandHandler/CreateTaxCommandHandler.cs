using ReserveProject.Infrastructure.Database;
using ReserveProject.Infrastructure.Repositories.Abstractions;
using ReserveProject.Shared.ApplicationInfrastructure;
using System.Threading;
using System.Threading.Tasks;
using ReserveProject.Application.Infrastructure;
using ReserveProject.Domain.Aggregates.TaxAggregate;
using ReserveProject.Domain.Aggregates.TaxAggregate.Commands;

namespace ReserveProject.Application.CommandHandlers.CustomerCommandHandler
{
    public class CreateTaxCommandHandler : CommandHandler<CreateTaxCommand>
    {
        private readonly ITaxRepository _taxRepository;
        private readonly IUnitOfWork _unitOfWork;

        public CreateTaxCommandHandler(PrimeDbContext invoicingDbContext,
                                            ITaxRepository taxRepository,
                                            IUnitOfWork unitOfWork) : base(invoicingDbContext)
        {
            _taxRepository = taxRepository;
            _unitOfWork = unitOfWork;
        }


        public async override Task<CommandExecutionResult> Handle(CreateTaxCommand request, CancellationToken cancellationToken)
        {
            var tax = Tax.Create(request.Name, request.Scope, request.Computation, request.Value);

            _taxRepository.Store(tax);
            await _unitOfWork.Save();

            return await Ok(DomainOperationResult.Create(tax.UId));
        }
    }
}
