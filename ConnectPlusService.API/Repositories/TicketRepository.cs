using ConnectPlus.API.Data;
using ConnectPlus.API.Interfaces;
using ConnectPlus.API.Models;
using Microsoft.EntityFrameworkCore;

namespace ConnectPlus.API.Repositories
{
    public class TicketRepository : ITicketRepository
    {
        private readonly ApplicationDbContext _context;

        public TicketRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public List<Ticket> GetAll()
        {
            return _context.Tickets.ToList();
        }

        public Ticket? GetById(int id)
        {
            return _context.Tickets.Find(id);
        }

        public void Add(Ticket ticket)
        {
            _context.Tickets.Add(ticket);
            _context.SaveChanges();
        }

        public void Update(Ticket ticket)
        {
            _context.Tickets.Update(ticket);
            _context.SaveChanges();
        }
    public int GetTotalCount()
{
    return _context.Tickets.Count();
}

public int GetCountByStatus(string status)
{
    return _context.Tickets.Count(t => t.Status == status);
}

public int GetHighPriorityCount()
{
    return _context.Tickets.Count(t => t.Priority == "High");
}
public int GetSLABreachedCount()
{
    var closedTickets = _context.Tickets
        .Where(t => t.Status == "Closed")
        .ToList();

    int breachedCount = 0;

    foreach (var ticket in closedTickets)
    {
        if (!ticket.ResolvedDate.HasValue)
            continue;

        var category = _context.TicketCategories
            .FirstOrDefault(c => c.CategoryId == ticket.CategoryId);

        if (category == null)
            continue;

        var resolutionHours =
            (ticket.ResolvedDate.Value - ticket.CreatedDate).TotalHours;

        if (resolutionHours > category.SLAHours)
            breachedCount++;
    }
    return breachedCount;
}

        // MUST match interface exactly
        public Ticket? GetOpenTicketByTitleAndCustomer(string title, int customerId)
        {
            return _context.Tickets
                .FirstOrDefault(t =>
                    t.Title == title &&
                    t.CustomerId == customerId &&
                    t.Status != "Closed");
        }
        public double GetAverageResolutionHours()
{
    var closedTickets = _context.Tickets
        .Where(t => t.Status == "Closed" && t.ResolvedDate != null)
        .ToList();

    if (!closedTickets.Any())
        return 0;

    return closedTickets
        .Average(t => (t.ResolvedDate!.Value - t.CreatedDate).TotalHours);
}
}
}