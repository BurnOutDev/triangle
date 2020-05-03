using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
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
        [HttpGet()]
        public IActionResult GetTested()
        {
            return new JsonResult(new
            {
                text = 5
            });
        }

    }
}
