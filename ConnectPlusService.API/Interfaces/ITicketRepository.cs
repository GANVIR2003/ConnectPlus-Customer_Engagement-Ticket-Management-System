using ConnectPlus.API.Models;

namespace ConnectPlus.API.Interfaces
{
    public interface ITicketRepository
    {
        List<Ticket> GetAll();
        Ticket? GetById(int id);
        void Add(Ticket ticket);
        void Update(Ticket ticket);
        int GetTotalCount();
        int GetCountByStatus(string status);
        int GetHighPriorityCount();
        int GetSLABreachedCount();
        double GetAverageResolutionHours();

        Ticket? GetOpenTicketByTitleAndCustomer(string title, int customerId);
    }
}