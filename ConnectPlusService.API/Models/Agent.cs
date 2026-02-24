using System.ComponentModel.DataAnnotations;

namespace ConnectPlus.API.Models
{
    public class Agent
    {
        [Key]
        public int AgentId { get; set; }

        public string? AgentName { get; set; }

        public string? Role { get; set; }
    }
}