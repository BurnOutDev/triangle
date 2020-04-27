using Microsoft.AspNetCore.Mvc;
using ReserveProject.Application.Execution;
using ReserveProject.Domain.Aggregates.ProductCategoryAggregate.Commands;
using ReserveProject.Shared.ApplicationInfrastructure;
using System.Threading.Tasks;
using ReserveProject.Application.Queries.ProductCategoryQueries;

namespace ReserveProject.Api.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class ProductCategoryController : ControllerBase
    {
        private readonly ICommandExecutor _commandExecutor;
        private readonly IQueryExecutor _queryExecutor;

        public ProductCategoryController(ICommandExecutor commandExecutor, IQueryExecutor queryExecutor)
        {
            _commandExecutor = commandExecutor;
            _queryExecutor = queryExecutor;
        }

        [HttpPost]
        public async Task<ActionResult<CommandExecutionResult>> CreateProductCategory([FromForm] CreateProductCategoryCommand createProductCategoryCommand)
        {
            return await _commandExecutor.Execute(createProductCategoryCommand);
        }
               
        [HttpPut]
        public async Task<ActionResult<CommandExecutionResult>> UpdateProductCategoryDetails([FromBody] UpdateProductCategoryCommand updateProductCategoryCommand)
        {
            return await _commandExecutor.Execute(updateProductCategoryCommand);
        }


        [HttpDelete]
        public async Task<ActionResult<CommandExecutionResult>> DeleteProductCategory([FromQuery] DeleteProductCategoryCommand deleteProductCategoryCommand)
        {
            return await _commandExecutor.Execute(deleteProductCategoryCommand);
        }

        [HttpGet]
        public async Task<ActionResult<QueryExecutionResult<ProductCategoryListQueryResult>>> ProductCategoryesList([FromQuery] ProductCategoryListQuery productCategoryListQuery)
        {
            return await _queryExecutor.Execute(productCategoryListQuery);
        }

        [HttpGet]
        public async Task<ActionResult<QueryExecutionResult<ProductCategoryDetailsQueryResult>>> ProductCategoryDetails([FromQuery] ProductCategoryDetailsQuery productCategoryDetailsQuery)
        {
            return await _queryExecutor.Execute(productCategoryDetailsQuery);
        }
    }
}
