using Event_Management_System.DTOs;
using Event_Management_System.Interfaces;
using Event_Management_System.Models;
namespace Event_Management_System.Services
{
    public class EventService : IEventService
    {
        private readonly IEventRepository _eventRepository;
        public EventService(IEventRepository eventRepository)
        {
            _eventRepository = eventRepository;
            
        }

        public async Task<int> SaveEventWithTicketsAsync(EventDto dto)
        {
            var eventEntity = new Event
            {
                EventName = dto.EventName,
                EventDescription = dto.EventDescription,
                StartDate = dto.StartDate,
                EndDate = dto.EndDate,
                Organizer = dto.Organizer,
                Tickets = dto.Tickets.Select(t => new Ticket
                {
                    TicketNo = t.TicketNo,
                    Price = t.Price
                }).ToList()
            };

            return await _eventRepository.CreateEventAsync(eventEntity);
        }


        public async Task<EventDto?> GetEventAsync(int id)
        {
            var ev = await _eventRepository.GetEventByIdAsync(id);
            if (ev == null) return null;

            return new EventDto
            {
                Id = ev.Id,
                EventName = ev.EventName,
                EventDescription = ev.EventDescription,
                StartDate = ev.StartDate,
                EndDate = ev.EndDate,
                Organizer = ev.Organizer,
                Tickets = ev.Tickets.Select(t => new TicketDto
                {
                    Id = t.Id,
                    TicketNo = t.TicketNo,
                    Price = t.Price,
                    EventId = t.EventId
                }).ToList()
            };
        }

    }
}
