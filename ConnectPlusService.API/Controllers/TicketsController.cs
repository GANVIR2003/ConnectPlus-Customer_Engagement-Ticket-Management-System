using Microsoft.AspNetCore.Mvc;
using ConnectPlus.API.Interfaces;
using ConnectPlus.API.Models;
using ConnectPlus.API.Exceptions;

namespace ConnectPlus.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TicketsController : ControllerBase
    {
        private readonly ITicketService _service;

        public TicketsController(ITicketService service)
        {
            _service = service;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(_service.GetAll());
        }
        [HttpPost]
public IActionResult Create(Ticket ticket)
{
    try
    {
        _service.CreateTicket(ticket);
        return Ok("Ticket created successfully.");
    }
    catch (DuplicateTicketException ex)
    {
        return BadRequest(ex.Message);
    }
}


        [HttpPut("{id}/status")]
public IActionResult UpdateStatus(int id, string status)
{
    try
    {
        _service.UpdateStatus(id, status);
        return Ok("Status updated successfully.");
    }
    catch (InvalidStatusTransitionException ex)
    {
        return BadRequest(ex.Message);
    }
}
    }
}