using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ReserveProject.Application.Services;
using ReserveProject.Domain.Queries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ReserveProject.Api.Controllers
{
    [Authorize]
    [ApiController]
    [Route("[controller]")]
    public class CustomerController : ControllerBase
    {
        public ICustomerService CustomerService { get; }

        public CustomerController(ICustomerService customerService)
        {
            CustomerService = customerService;
        }

        [HttpGet("[action]")]
        public CustomerProfileQueryResult Profile()
        {
            return CustomerService.Profile(UserId);
        }

        [HttpGet("[action]")]
        public CustomerFavoriteRestaurantsQueryResult FavoriteRestaurants()
        {
            return CustomerService.FavoriteRestaurants(UserId);
        }

        [HttpGet("[action]")]
        public CustomerReservationsQueryResult Reservations()
        {
            return CustomerService.Reservations(UserId);
        }

        public string UserId => User.FindFirst("sub").Value;
    }
}
