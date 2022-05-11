#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using FuelBase.Data;
using FuelBase.Models;
using Microsoft.AspNetCore.Authorization;

namespace FuelBase.Controllers
{
    public class TransportsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public TransportsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Transports
        public async Task<IActionResult> Index()
        {
            return View(await _context.Transport.ToListAsync());
        }

        // GET: Transports/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var transport = await _context.Transport
                .FirstOrDefaultAsync(m => m.Id == id);
            if (transport == null)
            {
                return NotFound();
            }

            return View(transport);
        }

        // GET: Transports/Create
        [Authorize]
        public IActionResult Create()
        {
            return View();
        }

        // POST: Transports/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,RouteNumber,TransportType,CargoType,CargoNowTon,CargoCapacityTon,FuelType,FuelNowLitre,FuelCapacityLitre,GpsLatitudeNow,GpsLongitudeNow")] Transport transport)
        {
            if (ModelState.IsValid)
            {
                _context.Add(transport);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(transport);
        }

        // GET: Transports/Edit/5
        [Authorize]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var transport = await _context.Transport.FindAsync(id);
            if (transport == null)
            {
                return NotFound();
            }
            return View(transport);
        }

        // POST: Transports/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize]
        public async Task<IActionResult> Edit(int id, [Bind("Id,RouteNumber,TransportType,CargoType,CargoNowTon,CargoCapacityTon,FuelType,FuelNowLitre,FuelCapacityLitre,GpsLatitudeNow,GpsLongitudeNow")] Transport transport)
        {
            if (id != transport.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(transport);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TransportExists(transport.Id))
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
            return View(transport);
        }

        // GET: Transports/Delete/5
        [Authorize]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var transport = await _context.Transport
                .FirstOrDefaultAsync(m => m.Id == id);
            if (transport == null)
            {
                return NotFound();
            }

            return View(transport);
        }

        // POST: Transports/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Authorize]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var transport = await _context.Transport.FindAsync(id);
            _context.Transport.Remove(transport);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TransportExists(int id)
        {
            return _context.Transport.Any(e => e.Id == id);
        }

        //GET: Transports/Search
        public async Task<IActionResult> Search()
        {
            return View();
        } 
        
        //POST: Transports/SearchResults
        public async Task<IActionResult> SearchResults(string searchPhrase)
        {
            return View(nameof(Index), await _context.Transport.Where(x => x.RouteNumber.ToString() == searchPhrase).ToListAsync());
        }
    }
}
