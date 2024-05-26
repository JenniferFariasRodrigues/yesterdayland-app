using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace YesterdaylandAPI.Server.Controllers
{
    
    [ApiController]
    [Route("api/[controller]")]
    public class EventsController : ControllerBase
    {
        //For the constructor
        private readonly AppDbContext _context;
        public EventsController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Event>>> GetEvents()
        {
            return await _context.Events.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Event>> GetEvent(int id)
        {
            var @event = await _context.Events.FindAsync(id);
            if (@event == null)
            {
                return NotFound();
            }

            return @event;
        }

        [HttpPost]
        public async Task<ActionResult<Event>> PostEvent(Event @event)
        {
            //take the data and save on a DB
            _context.Events.Add(@event);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetEvent), new { id = @event.Id }, @event);
        }
    }
}