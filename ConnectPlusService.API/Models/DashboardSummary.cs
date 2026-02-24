namespace ConnectPlus.API.Models
{
    public class DashboardSummary
    {
        public int TotalTickets { get; set; }
        public int OpenTickets { get; set; }
        public int InProgressTickets { get; set; }
        public int ClosedTickets { get; set; }
        public int HighPriorityTickets { get; set; }
        public int SLABreachedTickets { get; set; }
        public double AverageResolutionHours { get; set; }
    }
}