using etkinlikk.Data;
using etkinlikk.Models;
using Microsoft.AspNetCore.Mvc;

namespace etkinlikk.Controllers
{
    public class LikeController : Controller
    {
        private readonly EventDBContext _context;

        public LikeController(EventDBContext context)
        {
            _context = context;
        }

        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> Add(int eid,int uid)
        //{
        //    Likee likee = new() { ShowGroundId = eid, UserrID = uid, LikeeDate = DateTime.Now };
        //    await _context.Likees.AddAsync(likee);
        //    await _context.SaveChangesAsync();
        //    return View();
        //}
    }
}
