using Microsoft.AspNetCore.Mvc;
using ReserveProject.Application.Execution;
using ReserveProject.Domain.Aggregates.SalesPersonAggregate.Commands;
using ReserveProject.Shared.ApplicationInfrastructure;
using System.Threading.Tasks;
using ReserveProject.Application.Queries.SalesPersonQueries;

namespace ReserveProject.Api.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class SalesPersonController : ControllerBase
    {
        private readonly ICommandExecutor _commandExecutor;
        private readonly IQueryExecutor _queryExecutor;

        public SalesPersonController(ICommandExecutor commandExecutor, IQueryExecutor queryExecutor)
        {
            _commandExecutor = commandExecutor;
            _queryExecutor = queryExecutor;
        }

        [HttpPost]
        public async Task<ActionResult<CommandExecutionResult>> CreateSalesPerson([FromForm] CreateSalesPersonCommand createSalesPersonCommand)
        {
            return await _commandExecutor.Execute(createSalesPersonCommand);
        }
               
        [HttpPut]
        public async Task<ActionResult<CommandExecutionResult>> UpdateSalesPersonDetails([FromBody] UpdateSalesPersonCommand updateSalesPersonCommand)
        {
            return await _commandExecutor.Execute(updateSalesPersonCommand);
        }


        [HttpDelete]
        public async Task<ActionResult<CommandExecutionResult>> DeleteSalesPerson([FromQuery] DeleteSalesPersonCommand deleteSalesPersonCommand)
        {
            return await _commandExecutor.Execute(deleteSalesPersonCommand);
        }

        [HttpGet]
        public async Task<ActionResult<QueryExecutionResult<SalesPersonListQueryResult>>> SalesPersonesList([FromQuery] SalesPersonListQuery salesPersonListQuery)
        {
            return await _queryExecutor.Execute(salesPersonListQuery);
        }

        [HttpGet]
        public async Task<ActionResult<QueryExecutionResult<SalesPersonDetailsQueryResult>>> SalesPersonDetails([FromQuery] SalesPersonDetailsQuery salesPersonDetailsQuery)
        {
            return await _queryExecutor.Execute(salesPersonDetailsQuery);
        }
    }
}
