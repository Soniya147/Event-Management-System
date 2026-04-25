using Event_Management_System.DTOs;

namespace Event_Management_System.Interfaces
{
    public interface IEventService
    {
        Task<int> SaveEventWithTicketsAsync(EventDto eventDto);
        Task<EventDto?> GetEventAsync(int id);
    }
}
