using Microsoft.AspNetCore.Mvc;
using ConnectPlus.API.Interfaces;
using ConnectPlus.API.Models;

namespace ConnectPlus.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CustomersController : ControllerBase
    {
        private readonly ICustomerService _service;

        public CustomersController(ICustomerService service)
        {
            _service = service;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(_service.GetAll());
        }

        [HttpPost]
        public IActionResult Create(Customer customer)
        {
            try
            {
                _service.CreateCustomer(customer);
                return Ok(customer);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}