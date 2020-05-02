using Microsoft.AspNetCore.Mvc;
using ReserveProject.Application.Execution;
using ReserveProject.Domain.Aggregates.BankAccountAggregate.Commands;
using ReserveProject.Shared.ApplicationInfrastructure;
using System.Threading.Tasks;
using ReserveProject.Application.Queries.BankAccountQueries;

namespace ReserveProject.Api.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class BankAccountController : ControllerBase
    {
        private readonly ICommandExecutor _commandExecutor;
        private readonly IQueryExecutor _queryExecutor;

        public BankAccountController(ICommandExecutor commandExecutor, IQueryExecutor queryExecutor)
        {
            _commandExecutor = commandExecutor;
            _queryExecutor = queryExecutor;
        }

        [HttpPost]
        public async Task<ActionResult<CommandExecutionResult>> CreateBankAccount([FromForm] CreateBankAccountCommand createBankAccountCommand)
        {
            return await _commandExecutor.Execute(createBankAccountCommand);
        }
               
        [HttpPut]
        public async Task<ActionResult<CommandExecutionResult>> UpdateBankAccountDetails([FromBody] UpdateBankAccountCommand updateBankAccountCommand)
        {
            return await _commandExecutor.Execute(updateBankAccountCommand);
        }


        [HttpDelete]
        public async Task<ActionResult<CommandExecutionResult>> DeleteBankAccount([FromQuery] DeleteBankAccountCommand deleteBankAccountCommand)
        {
            return await _commandExecutor.Execute(deleteBankAccountCommand);
        }

        [HttpGet]
        public async Task<ActionResult<QueryExecutionResult<BankAccountListQueryResult>>> BankAccountesList([FromQuery] BankAccountListQuery bankAccountListQuery)
        {
            return await _queryExecutor.Execute(bankAccountListQuery);
        }

        [HttpGet]
        public async Task<ActionResult<QueryExecutionResult<BankAccountDetailsQueryResult>>> BankAccountDetails([FromQuery] BankAccountDetailsQuery bankAccountDetailsQuery)
        {
            return await _queryExecutor.Execute(bankAccountDetailsQuery);
        }
    }
}
