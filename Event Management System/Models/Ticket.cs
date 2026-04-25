namespace Event_Management_System.Models
{
    public class Ticket
    {
        public int Id { get; set; }
        public string TicketNo { get; set; } = string.Empty;
        public decimal Price { get; set; }
        public int EventId { get; set; }
        public Event? Event { get; set; }

    }
}
