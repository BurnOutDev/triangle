using Microsoft.AspNetCore.Mvc;
using ReserveProject.Application.Execution;
using ReserveProject.Domain.Aggregates.PartyAggregate.Commands;
using ReserveProject.Shared.ApplicationInfrastructure;
using System.Threading.Tasks;
using ReserveProject.Application.Queries.PartyQueries;

namespace ReserveProject.Api.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class PartyController : ControllerBase
    {
        private readonly ICommandExecutor _commandExecutor;
        private readonly IQueryExecutor _queryExecutor;

        public PartyController(ICommandExecutor commandExecutor, IQueryExecutor queryExecutor)
        {
            _commandExecutor = commandExecutor;
            _queryExecutor = queryExecutor;
        }

        [HttpPost]
        public async Task<ActionResult<CommandExecutionResult>> CreateParty([FromBody] CreatePartyCommand createPartyCommand)
        {
            return await _commandExecutor.Execute(createPartyCommand);
        }
               
        [HttpPut]
        public async Task<ActionResult<CommandExecutionResult>> UpdatePartyDetails([FromBody] UpdatePartyCommand updatePartyCommand)
        {
            return await _commandExecutor.Execute(updatePartyCommand);
        }

        [HttpPut]
        public async Task<ActionResult<CommandExecutionResult>> AddBankAccountToParty([FromBody] AddBankAccountToPartyCommand addBankAccountToPartyCommand)
        {
            return await _commandExecutor.Execute(addBankAccountToPartyCommand);
        }

        [HttpPut]
        public async Task<ActionResult<CommandExecutionResult>> DeleteBankAccountFromParty([FromBody] DeleteBankAccountFromPartyCommand deleteBankAccountFromPartyCommand)
        {
            return await _commandExecutor.Execute(deleteBankAccountFromPartyCommand);
        }

        [HttpDelete]
        public async Task<ActionResult<CommandExecutionResult>> DeleteParty([FromQuery] DeletePartyCommand deletePartyCommand)
        {
            return await _commandExecutor.Execute(deletePartyCommand);
        }

        [HttpGet]
        public async Task<ActionResult<QueryExecutionResult<PartyListQueryResult>>> PartyesList([FromQuery] PartyListQuery bankAccountListQuery)
        {
            return await _queryExecutor.Execute(bankAccountListQuery);
        }

        [HttpGet]
        public async Task<ActionResult<QueryExecutionResult<PartyDetailsQueryResult>>> PartyDetails([FromQuery] PartyDetailsQuery bankAccountDetailsQuery)
        {
            return await _queryExecutor.Execute(bankAccountDetailsQuery);
        }
    }
}
