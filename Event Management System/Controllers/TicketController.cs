using Event_Management_System.DTOs;
using Event_Management_System.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Event_Management_System.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TicketController : Controller
    {
        private readonly ITicketService _ticketService;

        public TicketController(ITicketService ticketService)
        {
            _ticketService = ticketService;
        }

        // These endpoints are NOT used for the in-memory jQuery table,
        // but available if you want DB-persisted ticket operations separately.

        [HttpPost]
        public async Task<IActionResult> Add([FromBody] TicketDto dto)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);
            var result = await _ticketService.AddTicketAsync(dto);
            return Ok(result);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] TicketDto dto)
        {
            dto.Id = id;
            var result = await _ticketService.UpdateTicketAsync(dto);
            return Ok(result);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _ticketService.DeleteTicketAsync(id);
            return Ok(new { success = result });
        }
    }
    
}
