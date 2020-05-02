using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ReserveProject.Application.Execution;
using ReserveProject.Application.Queries.Currency;
using ReserveProject.Domain.Aggregates.CurrencyAggregate.Commands;
using ReserveProject.Shared.ApplicationInfrastructure;

namespace ReserveProject.Api.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class CurrencyController : ControllerBase
    {
        private readonly ICommandExecutor _commandExecutor;
        private readonly IQueryExecutor _queryExecutor;

        public CurrencyController(ICommandExecutor commandExecutor, IQueryExecutor queryExecutor)
        {
            _commandExecutor = commandExecutor;
            _queryExecutor = queryExecutor;
        }

        [HttpGet]
        public async Task<ActionResult<QueryExecutionResult<CurrenciesListQueryResult>>> CurrenciesList([FromQuery] CurrenciesListQuery currenciesListQuery)
        {
            return await _queryExecutor.Execute(currenciesListQuery);
        }

        [HttpGet]
        public async Task<ActionResult<QueryExecutionResult<CurrencyDetailsQueryResult>>> CurrencyDetails([FromQuery] CurrencyDetailsQuery currencyDetailsQuery)
        {
            return await _queryExecutor.Execute(currencyDetailsQuery);
        }

        [HttpPost]
        public async Task<ActionResult<CommandExecutionResult>> CreateCurrency([FromBody] CreateCurrencyCommand createCurrencyCommand)
        {
            return await _commandExecutor.Execute(createCurrencyCommand);
        }

        [HttpPut]
        public async Task<ActionResult<CommandExecutionResult>> EditCurrency([FromBody] EditCurrencyCommand editCurrencyCommand)
        {
            return await _commandExecutor.Execute(editCurrencyCommand);
        }

        [HttpDelete]
        public async Task<ActionResult<CommandExecutionResult>> DeleteCurrency([FromQuery] DeleteCurrencyCommand deleteCurrencyCommand)
        {
            return await _commandExecutor.Execute(deleteCurrencyCommand);
        }
    }
}
