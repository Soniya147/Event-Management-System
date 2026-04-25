namespace Event_Management_System.Models
{
    public class Event
    {
        public int Id { get; set; }
        public string EventName { get; set; } = string.Empty;
        public string EventDescription { get; set; } = string.Empty;
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string Organizer { get; set; } = string.Empty;
        public ICollection<Ticket> Tickets { get; set; } = new List<Ticket>();

    }
}
