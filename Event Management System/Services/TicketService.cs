using Event_Management_System.DTOs;
using Event_Management_System.Interfaces;
using Event_Management_System.Models;

namespace Event_Management_System.Services
{
    public class TicketService : ITicketService
    {
        private readonly ITicketRepository _ticketRepository;

        public TicketService(ITicketRepository ticketRepository)
        {
            _ticketRepository = ticketRepository;
        }

        public async Task<TicketDto> AddTicketAsync(TicketDto dto)
        {
            var ticket = new Ticket
            {
                TicketNo = dto.TicketNo,
                Price = dto.Price,
                EventId = dto.EventId
            };
            var result = await _ticketRepository.AddTicketAsync(ticket);
            dto.Id = result.Id;
            return dto;
        }

        public async Task<TicketDto> UpdateTicketAsync(TicketDto dto)
        {
            var ticket = await _ticketRepository.GetTicketByIdAsync(dto.Id)
                ?? throw new Exception("Ticket not found");

            ticket.TicketNo = dto.TicketNo;
            ticket.Price = dto.Price;
            await _ticketRepository.UpdateTicketAsync(ticket);
            return dto;
        }

        public async Task<bool> DeleteTicketAsync(int id)
            => await _ticketRepository.DeleteTicketAsync(id);
    }
}
