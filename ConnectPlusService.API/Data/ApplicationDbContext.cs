using Microsoft.EntityFrameworkCore;
using ConnectPlus.API.Models;

namespace ConnectPlus.API.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions options)
            : base(options)
        {
        }

        public DbSet<Customer> Customers => Set<Customer>();
        public DbSet<Agent> Agents => Set<Agent>();
        public DbSet<TicketCategory> TicketCategories => Set<TicketCategory>();
        public DbSet<Ticket> Tickets => Set<Ticket>();
    }
}