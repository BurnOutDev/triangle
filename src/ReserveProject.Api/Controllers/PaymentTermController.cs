using Microsoft.AspNetCore.Mvc;
using ReserveProject.Application.Execution;
using ReserveProject.Domain.Aggregates.PaymentTermAggregate.Commands;
using ReserveProject.Shared.ApplicationInfrastructure;
using System.Threading.Tasks;
using ReserveProject.Application.Queries.PaymentTermQueries;

namespace ReserveProject.Api.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class PaymentTermController : ControllerBase
    {
        private readonly ICommandExecutor _commandExecutor;
        private readonly IQueryExecutor _queryExecutor;

        public PaymentTermController(ICommandExecutor commandExecutor, IQueryExecutor queryExecutor)
        {
            _commandExecutor = commandExecutor;
            _queryExecutor = queryExecutor;
        }

        [HttpPost]
        public async Task<ActionResult<CommandExecutionResult>> CreatePaymentTerm([FromForm] CreatePaymentTermCommand createPaymentTermCommand)
        {
            return await _commandExecutor.Execute(createPaymentTermCommand);
        }
               
        [HttpPut]
        public async Task<ActionResult<CommandExecutionResult>> UpdatePaymentTermDetails([FromBody] UpdatePaymentTermCommand updatePaymentTermCommand)
        {
            return await _commandExecutor.Execute(updatePaymentTermCommand);
        }


        [HttpDelete]
        public async Task<ActionResult<CommandExecutionResult>> DeletePaymentTerm([FromQuery] DeletePaymentTermCommand deletePaymentTermCommand)
        {
            return await _commandExecutor.Execute(deletePaymentTermCommand);
        }

        [HttpGet]
        public async Task<ActionResult<QueryExecutionResult<PaymentTermListQueryResult>>> PaymentTermesList([FromQuery] PaymentTermListQuery paymentTermListQuery)
        {
            return await _queryExecutor.Execute(paymentTermListQuery);
        }

        [HttpGet]
        public async Task<ActionResult<QueryExecutionResult<PaymentTermDetailsQueryResult>>> PaymentTermDetails([FromQuery] PaymentTermDetailsQuery paymentTermDetailsQuery)
        {
            return await _queryExecutor.Execute(paymentTermDetailsQuery);
        }
    }
}
