using etkinlikk.Data;
using etkinlikk.Models;
using etkinlikk.ViewModel;
using Microsoft.AspNetCore.Authorization;
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
            x.ShowGroundCommenttsList = await _context.Commentts.Include(a=>a.Userr).Where(a => a.ShowGroundID == id).Take(5).OrderByDescending(a=>a.CommenttId).ToListAsync();
            return View(x);
        }

        [Authorize(Roles ="Member")]
        [HttpPost]
        public async Task<IActionResult> AddComment(string comment,int id)
        {
            int MyUserID = Convert.ToInt32(User.FindFirst(claim => claim.Type == System.Security.Claims.ClaimTypes.Sid)?.Value);
            Commentt commentt = new Commentt(){ ShowGroundID = id, UserrID = MyUserID, Content = comment, CommenttDate = DateTime.Now };
            await _context.Commentts.AddAsync(commentt);
            await _context.SaveChangesAsync();

            return RedirectToAction("", "ShowGroundDetail", new { id = id });

        }
    }
}
