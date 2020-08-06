using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ReserveProject.Application.Services;
using ReserveProject.Domain.Commands;
using ReserveProject.Domain.Queries;

namespace ReserveProject.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ReservationController : ControllerBase
    {
        public IReservationService ReservationService { get; }

        private readonly ILogger<ReservationController> _logger;

        public ReservationController(IReservationService reservationService, ILogger<ReservationController> logger)
        {
            ReservationService = reservationService;
            _logger = logger;
        }

        [HttpPost("[action]")]
        public void Reserve(ReserveCommand reserveCommand)
        {
            ReservationService.Reserve(UserId, reserveCommand);
        }

        public string UserId { get { return User.FindFirst("sub").Value; } }
    }
}
