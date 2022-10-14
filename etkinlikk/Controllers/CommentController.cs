using etkinlikk.Data;
using Microsoft.AspNetCore.Mvc;

namespace etkinlikk.Controllers
{
    public class CommentController : Controller
    {
        private readonly EventDBContext _context;

        public CommentController(EventDBContext context)
        {
            _context = context;
        }
        
        //public async Task<IActionResult> Commentt
    }
}
