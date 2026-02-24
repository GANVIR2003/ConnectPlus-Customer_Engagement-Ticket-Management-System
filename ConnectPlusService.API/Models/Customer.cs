using System.ComponentModel.DataAnnotations;

namespace ConnectPlus.API.Models
{
    public class Customer
    {
        [Key]
        public int CustomerId { get; set; }

        public string? FullName { get; set; }

        public string? Email { get; set; }

        public string? PhoneNumber { get; set; }

        public DateTime CreatedDate { get; set; }
    }
}