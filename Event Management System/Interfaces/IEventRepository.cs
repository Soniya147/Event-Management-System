using Event_Management_System.Models;

namespace Event_Management_System.Interfaces
{
    public interface IEventRepository
    {
        Task<int> CreateEventAsync(Event eventEntity);
        Task<Event?> GetEventByIdAsync(int id);
        Task<IEnumerable<Event>> GetAllEventsAsync();

    }
}
