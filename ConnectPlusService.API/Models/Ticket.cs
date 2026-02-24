using System.ComponentModel.DataAnnotations;

namespace ConnectPlus.API.Models
{
    public class Ticket
    {
        [Key]
        public int TicketId { get; set; }

        public string? Title { get; set; }

        public string? Description { get; set; }

        public string? Status { get; set; }

        public string? Priority { get; set; }

        public DateTime CreatedDate { get; set; }

        public DateTime? ResolvedDate { get; set; }

        public int CustomerId { get; set; }

        public int AgentId { get; set; }

        public int CategoryId { get; set; }
    }
}