using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using etkinlikk.Data;
using etkinlikk.Models;
using etkinlikk.ViewModel;

namespace etkinlikk.Controllers
{
    public class ShowGroundController : Controller
    {
        private readonly EventDBContext _context;

        public ShowGroundController(EventDBContext context)
        {
            _context = context;
        }

        // GET: ShowGround
        public async Task<IActionResult> Index()
        {
            var eventDBContext = _context.ShowGrounds.Include(s => s.District);
            return View(await eventDBContext.ToListAsync());
        }

        // GET: ShowGround/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.ShowGrounds == null)
            {
                return NotFound();
            }
            ShowgroundHomeViewModel x = new();

            x.ShowGroundSubCategoryList = await _context.ShowGroundSubCategories.Include(a=>a.SubCategory).Where(a=>a.ShowGroundID == id).ToListAsync();
            x.ShowGround = await _context.ShowGrounds
                .Include(s => s.District)
                .FirstOrDefaultAsync(m => m.ShowGroundID == id);

            x.SubCategoryList = await _context.SubCategories.Where(a => !(x.ShowGroundSubCategoryList.Select(a => a.SubCategoryID).Contains(a.SubCategoryID))).ToListAsync();
            if (x.ShowGround == null)
            {
                return NotFound();
            }

            return View(x);
        }

        // GET: ShowGround/Create
        public IActionResult Create()
        {
            ViewData["DistrictID"] = new SelectList(_context.Districts, "DistrictID", "DistrictName");
            return View();
        }

        // POST: ShowGround/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ShowGroundID,ShowGroundID,SubCategoryID")] ShowGround showGround)
        {
            if (ModelState.IsValid)
            {
                _context.Add(showGround);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["DistrictID"] = new SelectList(_context.Districts, "DistrictID", "DistrictName", showGround.DistrictID);
            return View(showGround);
        }

        // GET: ShowGround/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.ShowGrounds == null)
            {
                return NotFound();
            }

            var showGround = await _context.ShowGrounds.FindAsync(id);
            if (showGround == null)
            {
                return NotFound();
            }
            ViewData["DistrictID"] = new SelectList(_context.Districts, "DistrictID", "DistrictName", showGround.DistrictID);
            return View(showGround);
        }

        // POST: ShowGround/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ShowGroundID,ShowGroundName,Capacity,Address,DistrictID")] ShowGround showGround)
        {
            if (id != showGround.ShowGroundID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(showGround);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ShowGroundExists(showGround.ShowGroundID))
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
            ViewData["DistrictID"] = new SelectList(_context.Districts, "DistrictID", "DistrictName", showGround.DistrictID);
            return View(showGround);
        }

        // GET: ShowGround/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.ShowGrounds == null)
            {
                return NotFound();
            }

            var showGround = await _context.ShowGrounds
                .Include(s => s.District)
                .FirstOrDefaultAsync(m => m.ShowGroundID == id);
            if (showGround == null)
            {
                return NotFound();
            }

            return View(showGround);
        }

        // POST: ShowGround/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.ShowGrounds == null)
            {
                return Problem("Entity set 'EventDBContext.ShowGrounds'  is null.");
            }
            var showGround = await _context.ShowGrounds.FindAsync(id);
            if (showGround != null)
            {
                _context.ShowGrounds.Remove(showGround);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ShowGroundExists(int id)
        {
            return _context.ShowGrounds.Any(e => e.ShowGroundID == id);
        }

        // POST: SubCategory/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddSubCategoryToShowGround(int id,[Bind("ShowGroundSubCatID,ShowGroundID,SubCategoryID")] ShowGroundSubCategory showGroundSubCategory)
        {
            showGroundSubCategory.ShowGroundID = id;
            _context.Add(showGroundSubCategory);
            await _context.SaveChangesAsync();
            return RedirectToAction("Details", "ShowGround", new { @id = id });
        }
    }
}

