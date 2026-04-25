using System.ComponentModel.DataAnnotations;

namespace Event_Management_System.DTOs
{
    public class EventDto
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Event Name is required")]
        public string EventName { get; set; }

        [Required(ErrorMessage = "Description is required")]
        public string EventDescription { get; set; }

        [Required(ErrorMessage = "Start Date is required")]
        public DateTime StartDate { get; set; }

        [Required(ErrorMessage = "End Date is required")]
        public DateTime EndDate { get; set; }

        [Required(ErrorMessage = "Organizer is required")]

        public string Organizer { get; set; }

        public List<TicketDto> Tickets { get; set; }

    }
}
