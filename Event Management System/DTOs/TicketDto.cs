using System.ComponentModel.DataAnnotations;

namespace Event_Management_System.DTOs
{
    public class TicketDto
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Ticket No is required")]
        public string TicketNo { get; set; }

        [Required(ErrorMessage ="Price is required")]
        [Range(0.01, double.MaxValue,ErrorMessage = "Price must be >0")]

        public decimal Price { get; set; }
        public int EventId { get; set; }
    }
}
