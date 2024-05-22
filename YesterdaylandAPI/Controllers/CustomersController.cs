using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using YesterdaylandAPI.Data;
using YesterdaylandAPI.Models;

[ApiController]
[Route("api/[controller]")]
public class CustomersController : ControllerBase
{
    private readonly YesterdaylandContext _context;

    public CustomersController(YesterdaylandContext context)
    {
        _context = context;
    }

    [HttpPost("{customerId}/tickets")]
    public async Task<ActionResult<Ticket>> BuyTicket(int customerId, int eventId)
    {
        var customer = await _context.Customers.FindAsync(customerId);
        var eventObj = await _context.Events.FindAsync(eventId);

        if (customer == null || eventObj == null)
            return NotFound();

        var ticket = new Ticket
        {
            Code = Guid.NewGuid().ToString(),
            CreateDate = DateTime.Now,
            CustomerId = customerId,
            EventId = eventId
        };

        _context.Tickets.Add(ticket);
        await _context.SaveChangesAsync();

        return CreatedAtAction(nameof(GetTickets), new { customerId }, ticket);
    }

    [HttpGet("{customerId}/tickets")]
    public async Task<ActionResult<IEnumerable<Ticket>>> GetTickets(int customerId)
    {
        return await _context.Tickets.Where(t => t.CustomerId == customerId).ToListAsync();
    }
}
