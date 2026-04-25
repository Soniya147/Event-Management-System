using Event_Management_System.DTOs;

namespace Event_Management_System.Interfaces
{
    public interface ITicketService
    {
        Task<TicketDto> AddTicketAsync(TicketDto dto);
        Task<TicketDto> UpdateTicketAsync(TicketDto dto);
        Task<bool> DeleteTicketAsync(int id);
    }
}
