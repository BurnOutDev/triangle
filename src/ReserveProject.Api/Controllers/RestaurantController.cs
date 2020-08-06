using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication.OpenIdConnect;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Protocols.OpenIdConnect;
using ReserveProject.Application;
using ReserveProject.Application.Services;
using ReserveProject.Domain;
using ReserveProject.Domain.Commands;
using ReserveProject.Domain.Queries;

namespace ReserveProject.Api.Controllers
{
    [Authorize]
    [ApiController]
    [Route("[controller]")]
    public class RestaurantController : ControllerBase
    {
        public IRestaurantService RestaurantService { get; }

        private readonly ILogger<ReservationController> _logger;

        public RestaurantController(IRestaurantService restaurantReservationService, ILogger<ReservationController> logger)
        {
            RestaurantService = restaurantReservationService;
            _logger = logger;
        }

        [HttpPost("[action]")]
        public void Create(AddRestaurantCommand addRestaurantCommand)
        {
            RestaurantService.AddRestaurant(addRestaurantCommand);
        }

        [HttpPatch("[action]")]
        public void ChangeBusinessHours(ChangeBusinessHoursCommand changeBusinessHoursCommand)
        {
            RestaurantService.ChangeBusinessHours(changeBusinessHoursCommand);
        }

        [HttpPost("[action]")]
        public void AddCuisine(AddCuisineCommand addCuisineCommand)
        {
            RestaurantService.AddCuisine(addCuisineCommand);
        }

        [HttpGet("[action]")]
        public async Task<IActionResult> GetTested()
        {
            var identityToken = await HttpContext.GetTokenAsync(OpenIdConnectParameterNames.IdToken);

            var claims = string.Join("\n", User.Claims.Select(claim => $"Claim type: {claim.Type}, Claim value: {claim.Value}"));

            return new ObjectResult($"{identityToken}\nClaims:\n{claims}");
        }

        [HttpGet("[action]")]
        public async Task Logout()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            await HttpContext.SignOutAsync(OpenIdConnectDefaults.AuthenticationScheme);
        }

        [HttpGet("[action]")]
        public IActionResult GetUserInfo()
        {
            return new JsonResult(new
            {
                Username = "burnoutdev"
            });
        }

        [HttpPost("[action]")]
        public RestaurantsPerCategoryQueryResult RestaurantsPerCategory(RestaurantsPerCategoryQuery restaurantsPerCategoryQuery)
        {
            return RestaurantService.RestaurantsPerCategory(restaurantsPerCategoryQuery);
        }

        [HttpGet("[action]")]
        public RestaurantsQueryResult Restaurants([FromQuery] RestaurantsQuery restaurantsQuery)
        {
            return RestaurantService.Restaurants(restaurantsQuery);
        }

        [HttpGet("[action]")]
        public CuisinesQueryResult Cuisines()
        {
            return RestaurantService.Cuisines();
        }

        [HttpGet("[action]")]
        public RestaurantProfileQueryResult Profile()
        {
            return RestaurantService.RestaurantProfile(UserId);
        }

        [HttpGet("[action]/{restaurantId}")]
        public RestaurantQueryResult Restaurant(int restaurantId)
        {
            return RestaurantService.Restaurant(new RestaurantQuery { RestaurantId = restaurantId });
        }

        [HttpPost("[action]")]
        public void Update(UpdateRestaurantCommand updateRestaurantCommand)
        {
            RestaurantService.UpdateRestaurant(UserId, updateRestaurantCommand);
        }

        [HttpGet("[action]")]
        public RestaurantReservationsQueryResult GetReservations()
        {
            return RestaurantService.GetReservations(UserId);
        }

        public string UserId { get { return User.FindFirst("sub").Value; } }
    }
}
