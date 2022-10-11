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
    public class ShowGroundSubCategoryController : Controller
    {
        private readonly EventDBContext _context;

        public ShowGroundSubCategoryController(EventDBContext context)
        {
            _context = context;
        }

        // GET: ShowGroundSubCategory
        public async Task<IActionResult> Index()
        {
              return View(await _context.ShowGroundSubCategories.ToListAsync());
        }

        // GET: ShowGroundSubCategory/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.ShowGroundSubCategories == null)
            {
                return NotFound();
            }

            var showGroundSubCategory = await _context.ShowGroundSubCategories
                .FirstOrDefaultAsync(m => m.ShowGroundSubCategoryID == id);
            if (showGroundSubCategory == null)
            {
                return NotFound();
            }

            return View(showGroundSubCategory);
        }

        // GET: ShowGroundSubCategory/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: ShowGroundSubCategory/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ShowGroundSubCategoryID")] ShowGroundSubCategory showGroundSubCategory)
        {
            if (ModelState.IsValid)
            {
                _context.Add(showGroundSubCategory);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(showGroundSubCategory);
        }

        // GET: ShowGroundSubCategory/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.ShowGroundSubCategories == null)
            {
                return NotFound();
            }

            var showGroundSubCategory = await _context.ShowGroundSubCategories.FindAsync(id);
            if (showGroundSubCategory == null)
            {
                return NotFound();
            }
            return View(showGroundSubCategory);
        }

        // POST: ShowGroundSubCategory/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ShowGroundSubCategoryID")] ShowGroundSubCategory showGroundSubCategory)
        {
            if (id != showGroundSubCategory.ShowGroundSubCategoryID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(showGroundSubCategory);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ShowGroundSubCategoryExists(showGroundSubCategory.ShowGroundSubCategoryID))
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
            return View(showGroundSubCategory);
        }

        // GET: ShowGroundSubCategory/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.ShowGroundSubCategories == null)
            {
                return NotFound();
            }

            var showGroundSubCategory = await _context.ShowGroundSubCategories
                .FirstOrDefaultAsync(m => m.ShowGroundSubCategoryID == id);
            if (showGroundSubCategory == null)
            {
                return NotFound();
            }

            return View(showGroundSubCategory);
        }

        // POST: ShowGroundSubCategory/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.ShowGroundSubCategories == null)
            {
                return Problem("Entity set 'EventDBContext.ShowGroundSubCategories'  is null.");
            }
            var showGroundSubCategory = await _context.ShowGroundSubCategories.FindAsync(id);
            if (showGroundSubCategory != null)
            {
                _context.ShowGroundSubCategories.Remove(showGroundSubCategory);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ShowGroundSubCategoryExists(int id)
        {
          return _context.ShowGroundSubCategories.Any(e => e.ShowGroundSubCategoryID == id);
        }
    }
}
