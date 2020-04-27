using Microsoft.AspNetCore.Mvc;
using ReserveProject.Application.Execution;
using ReserveProject.Domain.Aggregates.InvoiceAggregate.Commands;
using ReserveProject.Shared.ApplicationInfrastructure;
using System.Threading.Tasks;
using ReserveProject.Application.Queries.InvoiceQueries;

namespace ReserveProject.Api.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class InvoiceController : ControllerBase
    {
        private readonly ICommandExecutor _commandExecutor;
        private readonly IQueryExecutor _queryExecutor;

        public InvoiceController(ICommandExecutor commandExecutor, IQueryExecutor queryExecutor)
        {
            _commandExecutor = commandExecutor;
            _queryExecutor = queryExecutor;
        }

        [HttpPost]
        public async Task<ActionResult<CommandExecutionResult>> CreateInvoice([FromBody] CreateInvoiceCommand createInvoiceCommand)
        {
            return await _commandExecutor.Execute(createInvoiceCommand);
        }
               
        [HttpPut]
        public async Task<ActionResult<CommandExecutionResult>> UpdateInvoiceDetails([FromBody] UpdateInvoiceCommand updateInvoiceCommand)
        {
            return await _commandExecutor.Execute(updateInvoiceCommand);
        }

        [HttpPut]
        public async Task<ActionResult<CommandExecutionResult>> AddInvoiceLineToInvoice([FromBody] AddInvoiceLineToInvoiceCommand addInvoiceLineToInvoiceCommand)
        {
            return await _commandExecutor.Execute(addInvoiceLineToInvoiceCommand);
        }

        [HttpPut]
        public async Task<ActionResult<CommandExecutionResult>> DeleteInvoiceLineFromInvoice([FromBody] DeleteInvoiceLineFromInvoiceCommand deleteInvoiceLineFromInvoiceCommand)
        {
            return await _commandExecutor.Execute(deleteInvoiceLineFromInvoiceCommand);
        }

        [HttpDelete]
        public async Task<ActionResult<CommandExecutionResult>> DeleteInvoice([FromQuery] DeleteInvoiceCommand deleteInvoiceCommand)
        {
            return await _commandExecutor.Execute(deleteInvoiceCommand);
        }

        [HttpGet]
        public async Task<ActionResult<QueryExecutionResult<InvoiceListQueryResult>>> InvoiceesList([FromQuery] InvoiceListQuery taxListQuery)
        {
            return await _queryExecutor.Execute(taxListQuery);
        }

        [HttpGet]
        public async Task<ActionResult<QueryExecutionResult<InvoiceDetailsQueryResult>>> InvoiceDetails([FromQuery] InvoiceDetailsQuery taxDetailsQuery)
        {
            return await _queryExecutor.Execute(taxDetailsQuery);
        }
    }
}
