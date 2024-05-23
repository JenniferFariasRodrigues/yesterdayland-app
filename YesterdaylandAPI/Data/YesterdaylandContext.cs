using Microsoft.EntityFrameworkCore;
using YesterdaylandAPI.Models;

namespace YesterdaylandAPI.Data
{

    public class YesterdaylandContext : DbContext
    {
        public YesterdaylandContext(DbContextOptions<YesterdaylandContext> options)
                : base(options)
        {
        }
        public DbSet<Customer> Customers { get; set; } = default!;//to not warnings
        public DbSet<Event> Events { get; set; } = default!;
        public DbSet<Ticket> Tickets { get; set; } = default!;

        // public YesterdaylandContext(DbContextOptions<YesterdaylandContext> options) : base(options) { }
    }
}