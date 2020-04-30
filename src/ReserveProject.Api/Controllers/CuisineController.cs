using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ReserveProject.Application;
using ReserveProject.Domain;

namespace ReserveProject.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CuisineController : ControllerBase
    {
        private readonly ICuisineService _cuisineService;
        private readonly ILogger<CuisineController> _logger;

        public CuisineController(ICuisineService cuisineService, ILogger<CuisineController> logger)
        {
            _cuisineService = cuisineService;
            _logger = logger;
        }

        [HttpGet]
        public IEnumerable<CuisineModel> GetAll()
        {
            return _cuisineService.GetAll();
        }
    }
}
