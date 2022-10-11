using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using etkinlikk.Data;
using etkinlikk.Models;

namespace etkinlikk.Controllers
{
    public class DistrictController : Controller
    {
        private readonly EventDBContext _context;

        public DistrictController(EventDBContext context)
        {
            _context = context;
        }

        // GET: District
        public async Task<IActionResult> Index()
        {
            var eventDBContext = _context.Districts.Include(d => d.City);
            return View(await eventDBContext.ToListAsync());
        }

        // GET: District/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Districts == null)
            {
                return NotFound();
            }

            var district = await _context.Districts
                .Include(d => d.City)
                .FirstOrDefaultAsync(m => m.DistrictID == id);
            if (district == null)
            {
                return NotFound();
            }

            return View(district);
        }

        // GET: District/Create
        public IActionResult Create()
        {
            ViewData["CityID"] = new SelectList(_context.Cities, "CityID", "CityName");
            return View();
        }

        // POST: District/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("DistrictID,DistrictName,CityID")] District district)
        {
            if (ModelState.IsValid)
            {
                _context.Add(district);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["CityID"] = new SelectList(_context.Cities, "CityID", "CityName", district.CityID);
            return View(district);
        }

        // GET: District/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Districts == null)
            {
                return NotFound();
            }

            var district = await _context.Districts.FindAsync(id);
            if (district == null)
            {
                return NotFound();
            }
            ViewData["CityID"] = new SelectList(_context.Cities, "CityID", "CityName", district.CityID);
            return View(district);
        }

        // POST: District/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("DistrictID,DistrictName,CityID")] District district)
        {
            if (id != district.DistrictID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(district);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DistrictExists(district.DistrictID))
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
            ViewData["CityID"] = new SelectList(_context.Cities, "CityID", "CityName", district.CityID);
            return View(district);
        }

        // GET: District/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Districts == null)
            {
                return NotFound();
            }

            var district = await _context.Districts
                .Include(d => d.City)
                .FirstOrDefaultAsync(m => m.DistrictID == id);
            if (district == null)
            {
                return NotFound();
            }

            return View(district);
        }

        // POST: District/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Districts == null)
            {
                return Problem("Entity set 'EventDBContext.Districts'  is null.");
            }
            var district = await _context.Districts.FindAsync(id);
            if (district != null)
            {
                _context.Districts.Remove(district);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DistrictExists(int id)
        {
          return _context.Districts.Any(e => e.DistrictID == id);
        }
    }
}
