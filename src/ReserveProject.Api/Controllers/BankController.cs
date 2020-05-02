using Microsoft.AspNetCore.Mvc;
using ReserveProject.Application.Execution;
using ReserveProject.Domain.Aggregates.BankAggregate.Commands;
using ReserveProject.Shared.ApplicationInfrastructure;
using System.Threading.Tasks;
using ReserveProject.Application.Queries.BankQueries;

namespace ReserveProject.Api.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class BankController : ControllerBase
    {
        private readonly ICommandExecutor _commandExecutor;
        private readonly IQueryExecutor _queryExecutor;

        public BankController(ICommandExecutor commandExecutor, IQueryExecutor queryExecutor)
        {
            _commandExecutor = commandExecutor;
            _queryExecutor = queryExecutor;
        }

        [HttpPost]
        public async Task<ActionResult<CommandExecutionResult>> CreateBank([FromForm] CreateBankCommand createBankCommand)
        {
            return await _commandExecutor.Execute(createBankCommand);
        }
               
        [HttpPut]
        public async Task<ActionResult<CommandExecutionResult>> UpdateBankDetails([FromBody] UpdateBankCommand updateBankCommand)
        {
            return await _commandExecutor.Execute(updateBankCommand);
        }


        [HttpDelete]
        public async Task<ActionResult<CommandExecutionResult>> DeleteBank([FromQuery] DeleteBankCommand deleteBankCommand)
        {
            return await _commandExecutor.Execute(deleteBankCommand);
        }

        [HttpGet]
        public async Task<ActionResult<QueryExecutionResult<BankListQueryResult>>> BankesList([FromQuery] BankListQuery bankListQuery)
        {
            return await _queryExecutor.Execute(bankListQuery);
        }

        [HttpGet]
        public async Task<ActionResult<QueryExecutionResult<BankDetailsQueryResult>>> BankDetails([FromQuery] BankDetailsQuery bankDetailsQuery)
        {
            return await _queryExecutor.Execute(bankDetailsQuery);
        }
    }
}
