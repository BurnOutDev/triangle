using Microsoft.AspNetCore.Mvc;
using ReserveProject.Application.Execution;
using ReserveProject.Domain.Aggregates.TaxAggregate.Commands;
using ReserveProject.Shared.ApplicationInfrastructure;
using System.Threading.Tasks;
using ReserveProject.Application.Queries.TaxQueries;

namespace ReserveProject.Api.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class TaxController : ControllerBase
    {
        private readonly ICommandExecutor _commandExecutor;
        private readonly IQueryExecutor _queryExecutor;

        public TaxController(ICommandExecutor commandExecutor, IQueryExecutor queryExecutor)
        {
            _commandExecutor = commandExecutor;
            _queryExecutor = queryExecutor;
        }

        [HttpPost]
        public async Task<ActionResult<CommandExecutionResult>> CreateTax([FromForm] CreateTaxCommand createTaxCommand)
        {
            return await _commandExecutor.Execute(createTaxCommand);
        }
               
        [HttpPut]
        public async Task<ActionResult<CommandExecutionResult>> UpdateTaxDetails([FromBody] UpdateTaxCommand updateTaxCommand)
        {
            return await _commandExecutor.Execute(updateTaxCommand);
        }


        [HttpDelete]
        public async Task<ActionResult<CommandExecutionResult>> DeleteTax([FromQuery] DeleteTaxCommand deleteTaxCommand)
        {
            return await _commandExecutor.Execute(deleteTaxCommand);
        }

        [HttpGet]
        public async Task<ActionResult<QueryExecutionResult<TaxListQueryResult>>> TaxesList([FromQuery] TaxListQuery taxListQuery)
        {
            return await _queryExecutor.Execute(taxListQuery);
        }

        [HttpGet]
        public async Task<ActionResult<QueryExecutionResult<TaxDetailsQueryResult>>> TaxDetails([FromQuery] TaxDetailsQuery taxDetailsQuery)
        {
            return await _queryExecutor.Execute(taxDetailsQuery);
        }
    }
}
