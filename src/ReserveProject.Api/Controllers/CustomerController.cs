using Microsoft.AspNetCore.Mvc;
using ReserveProject.Application.Execution;
using ReserveProject.Application.Queries.CustomerQueries;
using ReserveProject.Domain.Aggregates.CustomerAggregate.Commands;
using ReserveProject.Shared.ApplicationInfrastructure;
using System.Threading.Tasks;

namespace ReserveProject.Api.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly ICommandExecutor _commandExecutor;
        private readonly IQueryExecutor _queryExecutor;

        public CustomerController(ICommandExecutor commandExecutor, IQueryExecutor queryExecutor)
        {
            _commandExecutor = commandExecutor;
            _queryExecutor = queryExecutor;
        }

        [HttpPost]
        public async Task<ActionResult<CommandExecutionResult>> CreateCustomer([FromForm] CreateCustomerCommand createCustomerCommand)
        {
            return await _commandExecutor.Execute(createCustomerCommand);
        }
               
        [HttpPut]
        public async Task<ActionResult<CommandExecutionResult>> UpdateCustomerDetails([FromBody] UpdateCustomerDetailsCommand updateCustomerDetailsCommand)
        {
            return await _commandExecutor.Execute(updateCustomerDetailsCommand);
        }


        [HttpDelete]
        public async Task<ActionResult<CommandExecutionResult>> DeleteCustomer([FromQuery] DeleteCustomerCommand deleteCustomerCommand)
        {
            return await _commandExecutor.Execute(deleteCustomerCommand);
        }

        [HttpGet]
        public async Task<ActionResult<QueryExecutionResult<CustomerListQueryResult>>> CustomerList([FromQuery] CustomerListQuery customerListQuery)
        {
            return await _queryExecutor.Execute(customerListQuery);
        }
    }
}
