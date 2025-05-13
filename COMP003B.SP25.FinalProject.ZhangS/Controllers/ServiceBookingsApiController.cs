using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using COMP003B.SP25.FinalProject.ZhangS.Data;
using COMP003B.SP25.FinalProject.ZhangS.Models;

namespace COMP003B.SP25.FinalProject.ZhangS.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ServiceBookingsApiController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public ServiceBookingsApiController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/ServiceBookingsApi
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ServiceBooking>>> GetServiceBookings()
        {
            return await _context.ServiceBookings.ToListAsync();
        }

        // GET: api/ServiceBookingsApi/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ServiceBooking>> GetServiceBooking(int id)
        {
            var serviceBooking = await _context.ServiceBookings.FindAsync(id);

            if (serviceBooking == null)
            {
                return NotFound();
            }

            return serviceBooking;
        }

        // PUT: api/ServiceBookingsApi/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutServiceBooking(int id, ServiceBooking serviceBooking)
        {
            if (id != serviceBooking.Id)
            {
                return BadRequest();
            }

            _context.Entry(serviceBooking).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ServiceBookingExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/ServiceBookingsApi
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<ServiceBooking>> PostServiceBooking(ServiceBooking serviceBooking)
        {
            _context.ServiceBookings.Add(serviceBooking);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetServiceBooking", new { id = serviceBooking.Id }, serviceBooking);
        }

        // DELETE: api/ServiceBookingsApi/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteServiceBooking(int id)
        {
            var serviceBooking = await _context.ServiceBookings.FindAsync(id);
            if (serviceBooking == null)
            {
                return NotFound();
            }

            _context.ServiceBookings.Remove(serviceBooking);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ServiceBookingExists(int id)
        {
            return _context.ServiceBookings.Any(e => e.Id == id);
        }
    }
}
