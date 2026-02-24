using System.ComponentModel.DataAnnotations;

namespace ConnectPlus.API.Models
{
    public class TicketCategory
    {
        [Key]
        public int CategoryId { get; set; }

        public string? CategoryName { get; set; }

        public int SLAHours { get; set; }
    }
}