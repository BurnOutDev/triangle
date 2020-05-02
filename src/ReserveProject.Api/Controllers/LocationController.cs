using Microsoft.AspNetCore.Mvc;
using ReserveProject.Application.Execution;
using ReserveProject.Application.Queries.Location;
using ReserveProject.Domain.Aggregates.Location.Commands;
using ReserveProject.Shared.ApplicationInfrastructure;
using System.Threading.Tasks;
using ReserveProject.Application.Queries.LocationQueries;

namespace ReserveProject.Api.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    [Produces("application/json")]
    public class LocationController : ControllerBase
    {
        private readonly ICommandExecutor _commandExecutor;
        private readonly IQueryExecutor _queryExecutor;

        public LocationController(ICommandExecutor commandExecutor, IQueryExecutor queryExecutor)
        {
            _commandExecutor = commandExecutor;
            _queryExecutor = queryExecutor;
        }

        [HttpPost]
        public async Task<ActionResult<CommandExecutionResult>> CreateCountry(
            [FromBody] CreateCountryCommand createCountryCommand)
        {
            return await _commandExecutor.Execute(createCountryCommand);

        }

        [HttpPost]
        public async Task<ActionResult<CommandExecutionResult>> CreateState(
           [FromBody] CreateStateCommand createStateCommand)
        {
            return await _commandExecutor.Execute(createStateCommand);
        }

        [HttpPost]
        public async Task<ActionResult<CommandExecutionResult>> CreateCity(
           [FromBody] CreateCityCommand createCityCommand)
        {
            return await _commandExecutor.Execute(createCityCommand);
        }



        [HttpPut]
        public async Task<ActionResult<CommandExecutionResult>> UpdateCountry(
          [FromBody] UpdateCountryCommand updateCountryCommand)
        {
            return await _commandExecutor.Execute(updateCountryCommand);
        }

        [HttpPut]
        public async Task<ActionResult<CommandExecutionResult>> UpdateState(
           [FromBody] UpdateStateCommand updateStateCommand)
        {
            return await _commandExecutor.Execute(updateStateCommand);
        }

        [HttpPut]
        public async Task<ActionResult<CommandExecutionResult>> UpdateCity(
           [FromBody] UpdateCityCommand updateCityCommand)
        {
            return await _commandExecutor.Execute(updateCityCommand);
        }



        [HttpDelete]
        public async Task<ActionResult<CommandExecutionResult>> DeleteCountry(
          [FromBody] DeleteCountryCommand deleteCountryCommand)
        {
            return await _commandExecutor.Execute(deleteCountryCommand);
        }

        [HttpDelete]
        public async Task<ActionResult<CommandExecutionResult>> DeleteState(
           [FromBody] DeleteStateCommand deleteStateCommand)
        {
            return await _commandExecutor.Execute(deleteStateCommand);
        }

        [HttpDelete]
        public async Task<ActionResult<CommandExecutionResult>> DeleteCity(
           [FromBody] DeleteCityCommand deleteCityCommand)
        {
            return await _commandExecutor.Execute(deleteCityCommand);
        }

        [HttpGet]
        public async Task<ActionResult<QueryExecutionResult<CountriesListQueryResult>>> CountriesList([FromQuery] CountriesListQuery countriesListQuery)
        {
            return await _queryExecutor.Execute(countriesListQuery);
        }

        [HttpGet]
        public async Task<ActionResult<QueryExecutionResult<CountryDetailsQueryResult>>> CountryDetails([FromQuery] CountryDetailsQuery countryDetailsQuery)
        {
            return await _queryExecutor.Execute(countryDetailsQuery);
        }

        [HttpGet]
        public async Task<ActionResult<QueryExecutionResult<StatesListQueryResult>>> StatesList([FromQuery]  StatesListQuery statesListQuery)
        {
            return await _queryExecutor.Execute(statesListQuery);
        }

        [HttpGet]
        public async Task<ActionResult<QueryExecutionResult<StateDetailsQueryResult>>> StateDetails([FromQuery]  StateDetailsQuery stateDetailsQuery)
        {
            return await _queryExecutor.Execute(stateDetailsQuery);
        }

        [HttpGet]
        public async Task<ActionResult<QueryExecutionResult<CitiesListQueryResult>>> CitiesList([FromQuery]  CitiesListQuery citiesListQuery)
        {
            return await _queryExecutor.Execute(citiesListQuery);
        }

        [HttpGet]
        public async Task<ActionResult<QueryExecutionResult<CityDetailsQueryResult>>> CityDetails([FromQuery]  CityDetailsQuery cityDetailsQuery)
        {
            return await _queryExecutor.Execute(cityDetailsQuery);
        }


        [HttpGet]
        public async Task<ActionResult<QueryExecutionResult<LocationListQueryResult>>> LocationList([FromQuery]  LocationListQuery locationListQuery)
        {
            return await _queryExecutor.Execute(locationListQuery);
        }
    }
}
