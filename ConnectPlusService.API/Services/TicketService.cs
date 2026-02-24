//Status validation
using ConnectPlus.API.Interfaces;
using ConnectPlus.API.Models;
using ConnectPlus.API.Exceptions;

namespace ConnectPlus.API.Services
{
    public class TicketService : ITicketService
    {
        private readonly ITicketRepository _repository;

        public TicketService(ITicketRepository repository)
        {
            _repository = repository;
        }

        public List<Ticket> GetAll()
        {
            return _repository.GetAll();
        }

public void CreateTicket(Ticket ticket)

{
    // BUSINESS RULE 1:
    // Prevent duplicate open tickets for same customer + same issue
    var existingTicket = _repository
        .GetOpenTicketByTitleAndCustomer(ticket.Title!, ticket.CustomerId);

    if (existingTicket != null)
    {
        // If duplicate found, throw error
        throw new DuplicateTicketException(
    "Duplicate open ticket already exists for this customer.");
    }

    // BUSINESS RULE 2:
    // Every new ticket always starts as Open
    ticket.Status = "Open";

    // Automatically set creation time
    ticket.CreatedDate = DateTime.Now;

    // Save to database
    _repository.Add(ticket);
}

        public void UpdateStatus(int id, string newStatus)
        {
            var ticket = _repository.GetById(id);

            if (ticket == null)
                throw new Exception("Ticket not found.");

            if (ticket.Status == "Open" && newStatus == "In Progress")
                ticket.Status = newStatus;

            else if (ticket.Status == "In Progress" && newStatus == "Closed")
            {
                ticket.Status = newStatus;
                ticket.ResolvedDate = DateTime.Now;
            }
            else
                throw new InvalidStatusTransitionException(
    "Invalid status transition.");

            _repository.Update(ticket);
        }
        public DashboardSummary GetDashboardSummary()
{
    return new DashboardSummary
    {
        TotalTickets = _repository.GetTotalCount(),
        OpenTickets = _repository.GetCountByStatus("Open"),
        InProgressTickets = _repository.GetCountByStatus("In Progress"),
        ClosedTickets = _repository.GetCountByStatus("Closed"),
        HighPriorityTickets = _repository.GetHighPriorityCount(),
        SLABreachedTickets = _repository.GetSLABreachedCount(),
        AverageResolutionHours = _repository.GetAverageResolutionHours()
    };
}
public double GetResolutionHours(int ticketId)
{
    var ticket = _repository.GetById(ticketId);

    if (ticket == null || ticket.ResolvedDate == null)
        return 0;

    return (ticket.ResolvedDate.Value - ticket.CreatedDate).TotalHours;
}
public double GetAverageResolutionHours()
{
    return _repository.GetAverageResolutionHours();
}
    }
}