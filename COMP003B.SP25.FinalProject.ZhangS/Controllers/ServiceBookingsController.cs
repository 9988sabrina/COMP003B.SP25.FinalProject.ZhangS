using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using COMP003B.SP25.FinalProject.ZhangS.Data;
using COMP003B.SP25.FinalProject.ZhangS.Models;

namespace COMP003B.SP25.FinalProject.ZhangS.Controllers
{
    public class ServiceBookingsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ServiceBookingsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: ServiceBookings
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.ServiceBookings.Include(s => s.Car).Include(s => s.Customer).Include(s => s.Mechanic).Include(s => s.ServiceType);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: ServiceBookings/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var serviceBooking = await _context.ServiceBookings
                .Include(s => s.Car)
                .Include(s => s.Customer)
                .Include(s => s.Mechanic)
                .Include(s => s.ServiceType)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (serviceBooking == null)
            {
                return NotFound();
            }

            return View(serviceBooking);
        }

        // GET: ServiceBookings/Create
        public IActionResult Create()
        {
            ViewData["CarId"] = new SelectList(_context.Cars, "Id", "Make");
            ViewData["CustomerId"] = new SelectList(_context.Customers, "Id", "Email");
            ViewData["MechanicId"] = new SelectList(_context.Mechanics, "Id", "CertificationNumber");
            ViewData["ServiceTypeId"] = new SelectList(_context.ServiceTypes, "Id", "Name");
            return View();
        }

        // POST: ServiceBookings/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,CarId,CustomerId,MechanicId,ServiceTypeId,ServiceDate,Cost,Notes")] ServiceBooking serviceBooking)
        {
            if (ModelState.IsValid)
            {
                _context.Add(serviceBooking);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["CarId"] = new SelectList(_context.Cars, "Id", "Make", serviceBooking.CarId);
            ViewData["CustomerId"] = new SelectList(_context.Customers, "Id", "Email", serviceBooking.CustomerId);
            ViewData["MechanicId"] = new SelectList(_context.Mechanics, "Id", "CertificationNumber", serviceBooking.MechanicId);
            ViewData["ServiceTypeId"] = new SelectList(_context.ServiceTypes, "Id", "Name", serviceBooking.ServiceTypeId);
            return View(serviceBooking);
        }

        // GET: ServiceBookings/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var serviceBooking = await _context.ServiceBookings.FindAsync(id);
            if (serviceBooking == null)
            {
                return NotFound();
            }
            ViewData["CarId"] = new SelectList(_context.Cars, "Id", "Make", serviceBooking.CarId);
            ViewData["CustomerId"] = new SelectList(_context.Customers, "Id", "Email", serviceBooking.CustomerId);
            ViewData["MechanicId"] = new SelectList(_context.Mechanics, "Id", "CertificationNumber", serviceBooking.MechanicId);
            ViewData["ServiceTypeId"] = new SelectList(_context.ServiceTypes, "Id", "Name", serviceBooking.ServiceTypeId);
            return View(serviceBooking);
        }

        // POST: ServiceBookings/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,CarId,CustomerId,MechanicId,ServiceTypeId,ServiceDate,Cost,Notes")] ServiceBooking serviceBooking)
        {
            if (id != serviceBooking.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(serviceBooking);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ServiceBookingExists(serviceBooking.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["CarId"] = new SelectList(_context.Cars, "Id", "Make", serviceBooking.CarId);
            ViewData["CustomerId"] = new SelectList(_context.Customers, "Id", "Email", serviceBooking.CustomerId);
            ViewData["MechanicId"] = new SelectList(_context.Mechanics, "Id", "CertificationNumber", serviceBooking.MechanicId);
            ViewData["ServiceTypeId"] = new SelectList(_context.ServiceTypes, "Id", "Name", serviceBooking.ServiceTypeId);
            return View(serviceBooking);
        }

        // GET: ServiceBookings/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var serviceBooking = await _context.ServiceBookings
                .Include(s => s.Car)
                .Include(s => s.Customer)
                .Include(s => s.Mechanic)
                .Include(s => s.ServiceType)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (serviceBooking == null)
            {
                return NotFound();
            }

            return View(serviceBooking);
        }

        // POST: ServiceBookings/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var serviceBooking = await _context.ServiceBookings.FindAsync(id);
            if (serviceBooking != null)
            {
                _context.ServiceBookings.Remove(serviceBooking);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ServiceBookingExists(int id)
        {
            return _context.ServiceBookings.Any(e => e.Id == id);
        }
    }
}
