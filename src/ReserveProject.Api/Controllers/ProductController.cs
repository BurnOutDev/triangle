using Microsoft.AspNetCore.Mvc;
using ReserveProject.Application.Execution;
using ReserveProject.Domain.Aggregates.ProductAggregate.Commands;
using ReserveProject.Shared.ApplicationInfrastructure;
using System.Threading.Tasks;
using ReserveProject.Application.Queries.ProductQueries;

namespace ReserveProject.Api.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly ICommandExecutor _commandExecutor;
        private readonly IQueryExecutor _queryExecutor;

        public ProductController(ICommandExecutor commandExecutor, IQueryExecutor queryExecutor)
        {
            _commandExecutor = commandExecutor;
            _queryExecutor = queryExecutor;
        }

        [HttpPost]
        public async Task<ActionResult<CommandExecutionResult>> CreateProduct([FromBody] CreateProductCommand createProductCommand)
        {
            return await _commandExecutor.Execute(createProductCommand);
        }
               
        [HttpPut]
        public async Task<ActionResult<CommandExecutionResult>> UpdateProductDetails([FromBody] UpdateProductCommand updateProductCommand)
        {
            return await _commandExecutor.Execute(updateProductCommand);
        }

        [HttpPut]
        public async Task<ActionResult<CommandExecutionResult>> AddTaxToProduct([FromBody] AddTaxToProductCommand addTaxToProductCommand)
        {
            return await _commandExecutor.Execute(addTaxToProductCommand);
        }

        [HttpPut]
        public async Task<ActionResult<CommandExecutionResult>> DeleteTaxFromProduct([FromBody] DeleteTaxFromProductCommand deleteTaxFromProductCommand)
        {
            return await _commandExecutor.Execute(deleteTaxFromProductCommand);
        }

        [HttpDelete]
        public async Task<ActionResult<CommandExecutionResult>> DeleteProduct([FromQuery] DeleteProductCommand deleteProductCommand)
        {
            return await _commandExecutor.Execute(deleteProductCommand);
        }

        [HttpGet]
        public async Task<ActionResult<QueryExecutionResult<ProductListQueryResult>>> ProductesList([FromQuery] ProductListQuery taxListQuery)
        {
            return await _queryExecutor.Execute(taxListQuery);
        }

        [HttpGet]
        public async Task<ActionResult<QueryExecutionResult<ProductDetailsQueryResult>>> ProductDetails([FromQuery] ProductDetailsQuery taxDetailsQuery)
        {
            return await _queryExecutor.Execute(taxDetailsQuery);
        }
    }
}
