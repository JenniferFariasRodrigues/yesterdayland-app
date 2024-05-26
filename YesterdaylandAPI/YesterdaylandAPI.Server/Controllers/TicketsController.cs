using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using YesterdaylandAPI.Server.DTOs;

namespace YesterdaylandAPI.Server.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TicketsController : ControllerBase
    {
        private readonly AppDbContext _context;

        public TicketsController(AppDbContext context)
        {
            _context = context;
        }

        //Soluton to solve serialize problem from tickent to take data from event
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TicketDto>>> GetTickets()
        {
            var tickets = await _context.Tickets
                .Select(t => new TicketDto
                {
                    Id = t.Id,
                    Code = t.Code,
                    CreateDate = t.CreateDate,
                    CustomerId = t.CustomerId,
                    EventId = t.EventId
                })
                .ToListAsync();

            return Ok(tickets);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<TicketDto>> GetTicket(int id)
        {
            var ticket = await _context.Tickets
                .Where(t => t.Id == id)
                .Select(t => new TicketDto
                {
                    Id = t.Id,
                    Code = t.Code,
                    CreateDate = t.CreateDate,
                    CustomerId = t.CustomerId,
                    EventId = t.EventId
                })
                .FirstOrDefaultAsync();

            if (ticket == null)
            {
                return NotFound();
            }

            return Ok(ticket);
        }

        [HttpPost]
        public async Task<ActionResult<TicketDto>> PostTicket(TicketDto ticketDto)
        {
            var ticket = new Ticket
            {
                Code = ticketDto.Code,
                CreateDate = ticketDto.CreateDate,
                CustomerId = ticketDto.CustomerId,
                EventId = ticketDto.EventId
            };

            _context.Tickets?.Add(ticket);
            await _context.SaveChangesAsync();

            ticketDto.Id = ticket.Id;

            return CreatedAtAction(nameof(GetTicket), new { id = ticket.Id }, ticketDto);
        }
    } 
}

        // old code
        //[HttpGet]
        //public async Task<ActionResult<IEnumerable<Ticket>>> GetTickets()
        //{
        //    return await _context.Tickets.ToListAsync();
        //}

        //[HttpGet("{id}")]
        //public async Task<ActionResult<Ticket>> GetTicket(int id)
        //{
        //    var ticket = await _context.Tickets.FindAsync(id);
        //    if (ticket == null)
        //    {
        //        return NotFound();
        //    }

        //    return ticket;
        //}

        //[HttpPost]
        //public async Task<ActionResult<Ticket>> PostTicket(Ticket ticket)
        //{
        //    _context.Tickets?.Add(ticket);
        //    await _context.SaveChangesAsync();
        //    return CreatedAtAction(nameof(GetTicket), new { id = ticket.Id }, ticket);
        //}
//    }
//}