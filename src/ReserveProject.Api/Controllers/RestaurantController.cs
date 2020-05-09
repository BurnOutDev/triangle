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

namespace ReserveProject.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class RestaurantController : ControllerBase
    {
        public IRestaurantManagementService RestaurantReservationService { get; }

        private readonly ILogger<ReservationController> _logger;

        public RestaurantController(IRestaurantManagementService restaurantReservationService, ILogger<ReservationController> logger)
        {
            RestaurantReservationService = restaurantReservationService;
            _logger = logger;
        }

        [HttpPost("[action]")]
        public void Create(AddRestaurantCommand addRestaurantCommand)
        {
            RestaurantReservationService.AddRestaurant(addRestaurantCommand);
        }

        [HttpPatch("[action]")]
        public void ChangeBusinessHours(ChangeBusinessHoursCommand changeBusinessHoursCommand)
        {
            RestaurantReservationService.ChangeBusinessHours(changeBusinessHoursCommand);
        }

        [HttpPost("[action]")]
        public void AddCuisine(AddCuisineCommand addCuisineCommand)
        {
            RestaurantReservationService.AddCuisine(addCuisineCommand);
        }

        [Authorize]
        [HttpGet("[action]")]
        public async Task<IActionResult> GetTested()
        {
            var identityToken = await HttpContext.GetTokenAsync(OpenIdConnectParameterNames.IdToken);

            var claims = string.Join("\n", User.Claims.Select(claim => $"Claim type: {claim.Type}, Claim value: {claim.Value}"));

            return new ObjectResult($"{identityToken}\nClaims:\n{claims}");
        }

        [Authorize]
        [HttpGet("[action]")]
        public async Task Logout()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            await HttpContext.SignOutAsync(OpenIdConnectDefaults.AuthenticationScheme);
        }
    }
}
