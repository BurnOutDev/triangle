using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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
    public class MenuController : ControllerBase
    {
        public IRestaurantManagementService RestaurantReservationService { get; }

        private readonly ILogger<ReservationController> _logger;

        public MenuController(IRestaurantManagementService restaurantReservationService, ILogger<ReservationController> logger)
        {
            RestaurantReservationService = restaurantReservationService;
            _logger = logger;
        }

        [HttpPost("[action]")]
        public void AddMenuItem(AddMenuItemCommand addMenuItemCommand)
        {
            RestaurantReservationService.AddMenuItem(addMenuItemCommand);
        }

        [HttpPost("[action]")]
        public void AddIngredient(AddIngredientCommand addIngredientCommand)
        {
            RestaurantReservationService.AddIngredient(addIngredientCommand);
        }

        [HttpPost("[action]")]
        public void AddCategory(AddCategoryCommand addCategoryCommand)
        {
            RestaurantReservationService.AddCategory(addCategoryCommand);
        }
    }
}
