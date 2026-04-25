using Event_Management_System.DTOs;
using Event_Management_System.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Event_Management_System.Controllers
{
    public class EventController :Controller
    {
        private readonly IEventService _eventService;

        public EventController(IEventService eventService)
        {
            _eventService = eventService;
        }

        // GET /Event/Create  → show the form
        public IActionResult Create() => View();

        // POST /Event/SaveEvent  → save everything to DB
        [HttpPost]
        public async Task<IActionResult> SaveEvent([FromBody] EventDto dto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var id = await _eventService.SaveEventWithTicketsAsync(dto);
            return Ok(new { success = true, eventId = id });
        }
    }
    }
