using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace YesterdaylandAPI.Server.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CustomersController : ControllerBase
    {
        private readonly AppDbContext _context;

        public CustomersController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/customers
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Customer>>> getcustomers()
        {
            return await _context.Customers.ToListAsync();
        }

        // GET: api/customers
        //[HttpGet]
        //public IActionResult GetCustomers()
        //{
        //    var customers = _context.Customers.ToList();
        //    return Ok(customers);
        //}

        [HttpGet("{id}")]
        public async Task<ActionResult<Customer>> GetCustomer(int id)
        {
            var customer = await _context.Customers.FindAsync(id);
            if (customer == null)
            {
                return NotFound();
            }

            return customer;
        }

        //// GET: api/customers/{id}
        //[HttpGet("{id}")]
        //public IActionResult GetCustomer(int id)
        //{
        //    var customer = _context.Customers.Find(id);
        //    if (customer == null)
        //    {
        //        return NotFound();
        //    }
        //    return Ok(customer);
        //}

        [HttpPost]
        public async Task<ActionResult<Customer>> PostCustomer(Customer customer)
        {
            _context.Customers?.Add(customer);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetCustomer), new { id = customer.Id }, customer);
        }

        //// POST: api/customers
        //[HttpPost]
        //public IActionResult CreateCustomer([FromBody] Customer customer)
        //{
        //    if (customer == null)
        //    {
        //        return BadRequest();
        //    }

        //    _context.Customers.Add(customer);
        //    _context.SaveChanges();
        //    return CreatedAtAction(nameof(GetCustomer), new { id = customer.Id }, customer);
        //}

        //// PUT: api/customers/{id}
        //[HttpPut("{id}")]
        //public IActionResult UpdateCustomer(int id, [FromBody] Customer customer)
        //{
        //    if (customer == null || customer.Id != id)
        //    {
        //        return BadRequest();
        //    }

        //    var existingCustomer = _context.Customers.Find(id);
        //    if (existingCustomer == null)
        //    {
        //        return NotFound();
        //    }

        //    existingCustomer.Name = customer.Name;
        //    existingCustomer.Email = customer.Email;

        //    _context.Customers.Update(existingCustomer);
        //    _context.SaveChanges();
        //    return NoContent();
        //}

        //// DELETE: api/customers/{id}
        //[HttpDelete("{id}")]
        //public IActionResult DeleteCustomer(int id)
        //{
        //    var customer = _context.Customers.Find(id);   
        //    if (customer == null)
        //    {
        //        return NotFound();
        //    }

        //    _context.Customers.Remove(customer);
        //    _context.SaveChanges();
        //    return NoContent();
        //}

    }
}