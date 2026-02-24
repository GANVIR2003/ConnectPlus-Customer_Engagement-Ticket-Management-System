using Microsoft.AspNetCore.Mvc;
using ConnectPlus.API.Interfaces;

namespace ConnectPlus.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class DashboardController : ControllerBase
    {
        private readonly ITicketService _service;

        public DashboardController(ITicketService service)
        {
            _service = service;
        }

        [HttpGet]
        public IActionResult GetSummary()
        {
            return Ok(_service.GetDashboardSummary());
        }
    }
}