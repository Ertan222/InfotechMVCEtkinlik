using etkinlikk.Data;
using etkinlikk.Models;
using etkinlikk.ViewModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace etkinlikk.Controllers
{
    public class ShowGroundDetailController : Controller
    {
        private readonly EventDBContext _context;

        public ShowGroundDetailController(EventDBContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index(int id)
        {
            ShowGroundDetailViewModel x = new ShowGroundDetailViewModel();

            x.ShowGround = await _context.ShowGrounds.Include(a => a.District).ThenInclude(b=>b.City).FirstOrDefaultAsync(a => a.ShowGroundID == id);
            x.RelatedShowGroundList = await _context.ShowGrounds.Include(a=>a.District).Where(a=>a.DistrictID == x.ShowGround.DistrictID && a.ShowGroundID != x.ShowGround.ShowGroundID).Take(5).ToListAsync();
            return View(x);
        }


    }
}
