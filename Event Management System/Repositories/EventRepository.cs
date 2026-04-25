using Event_Management_System.Data;
using Event_Management_System.Interfaces;
using Event_Management_System.Models;
using Microsoft.EntityFrameworkCore;

namespace Event_Management_System.Repositories
{
    public class EventRepository : IEventRepository
    {
        private readonly AppDbContext _context;

        public EventRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<int> CreateEventAsync(Event eventEntity)
        {
            _context.Events.Add(eventEntity);
            await _context.SaveChangesAsync();
            return eventEntity.Id;
        }

        public async Task<Event?> GetEventByIdAsync(int id)
        {
            // Optimized: Include tickets in single query (no N+1)
            return await _context.Events
                .Include(e => e.Tickets)
                .AsNoTracking()
                .FirstOrDefaultAsync(e => e.Id == id);
        }

        public async Task<IEnumerable<Event>> GetAllEventsAsync()
        {
            return await _context.Events
                .Include(e => e.Tickets)
                .AsNoTracking()
                .ToListAsync();
        }
    }
}
