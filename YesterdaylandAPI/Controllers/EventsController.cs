using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using YesterdaylandAPI.Data;
using YesterdaylandAPI.Models;

[ApiController]
[Route("api/[controller]")]
public class EventsController : ControllerBase
{
    private readonly YesterdaylandContext _context;

    public EventsController(YesterdaylandContext context)
    {
        _context = context;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<Event>>> GetEvents()
    {
        return await _context.Events.ToListAsync();
    }
}
