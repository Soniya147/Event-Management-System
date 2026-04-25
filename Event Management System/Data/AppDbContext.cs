using Event_Management_System.Models;
using Microsoft.EntityFrameworkCore;

namespace Event_Management_System.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Event> Events => Set<Event>();
        public DbSet<Ticket> Tickets => Set<Ticket>();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Event config
            modelBuilder.Entity<Event>(e =>
            {
                e.HasKey(x => x.Id);
                e.Property(x => x.EventName).IsRequired().HasMaxLength(200);
                e.Property(x => x.Organizer).IsRequired().HasMaxLength(200);
                e.Property(x => x.EventDescription).IsRequired();
            });

            // Ticket config
            modelBuilder.Entity<Ticket>(t =>
            {
                t.HasKey(x => x.Id);
                t.Property(x => x.TicketNo).IsRequired().HasMaxLength(50);
                t.Property(x => x.Price).HasColumnType("decimal(18,2)");

                // Relationship: One Event → Many Tickets
                t.HasOne(x => x.Event)
                 .WithMany(x => x.Tickets)
                 .HasForeignKey(x => x.EventId)
                 .OnDelete(DeleteBehavior.Cascade);
            });
        }
    }
    }
