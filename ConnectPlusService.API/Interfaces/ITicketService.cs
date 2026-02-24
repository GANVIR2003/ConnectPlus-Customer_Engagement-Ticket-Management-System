using ConnectPlus.API.Models;

namespace ConnectPlus.API.Interfaces
{
    public interface ITicketService
    {
        List<Ticket> GetAll();
        void CreateTicket(Ticket ticket);
        void UpdateStatus(int id, string newStatus);
        double GetAverageResolutionHours();
        DashboardSummary GetDashboardSummary();
    }
}