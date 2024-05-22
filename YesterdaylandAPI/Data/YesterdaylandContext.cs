using Microsoft.EntityFrameworkCore;
using YesterdaylandAPI.Models;

namespace YesterdaylandAPI.Data
{

    public class YesterdaylandContext : DbContext
{
    public DbSet<Customer> Customers { get; set; }
    public DbSet<Event> Events { get; set; }
    public DbSet<Ticket> Tickets { get; set; }

    public YesterdaylandContext(DbContextOptions<YesterdaylandContext> options) : base(options) { }
}

}