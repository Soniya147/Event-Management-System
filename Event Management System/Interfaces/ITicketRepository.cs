using Event_Management_System.Models;

namespace Event_Management_System.Interfaces
{
    public interface ITicketRepository
    {

        Task<Ticket> AddTicketAsync(Ticket ticket);
        Task<Ticket?> GetTicketByIdAsync(int id);
        Task<Ticket> UpdateTicketAsync(Ticket ticket);
        Task<bool> DeleteTicketAsync(int id);
        Task<IEnumerable<Ticket>> GetTicketsByEventIdAsync(int eventId);

    }
}
