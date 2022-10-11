using etkinlikk.Data;
using etkinlikk.Models;
using etkinlikk.ViewModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Diagnostics;

namespace etkinlikk.Controllers
{
    public class HomeController : Controller
    {
        private readonly EventDBContext _db;

        public HomeController(EventDBContext db)
        {
            _db = db;
        }
        public async Task<IActionResult> Index(int? cat, int? subcat, int? cit, int? dis, string filter, string searching)
        {
            HomeViewModel x = new();
            x.CategoryList = await _db.Categories.ToListAsync();
            x.SelectedSubCategory = await _db.SubCategories.FirstOrDefaultAsync(a => a.SubCategoryID == subcat);
            x.SubCategoryList = await _db.SubCategories.Where(a => a.CategoryID == cat).ToListAsync();
            if (x.SubCategoryList.Count == 0 && subcat != null)
            {
                x.SubCategoryList = await _db.SubCategories.Where(a => a.CategoryID == x.SelectedSubCategory.CategoryID).ToListAsync();
            }
            x.CitiesList = await _db.Cities.ToListAsync();
            x.DistrictsList = await _db.Districts.Where(a => a.CityID == cit).ToListAsync();
            x.SelectedCategoryID = cat;
            x.SelectedCityID = cit;

            List<int> showgroundListBySubCategoryId = _db.ShowGroundSubCategories.Where(a => a.SubCategoryID == subcat || subcat == null).Select(a => a.ShowGroundID).ToList();


            x.ShowgroundsList = await _db.ShowGrounds.
            Where(a => a.DistrictID == dis || dis == null).
            Where(a => x.DistrictsList.Select(b => b.DistrictID).Contains(a.DistrictID) || cit == null).
            Where(a => showgroundListBySubCategoryId.Contains(a.ShowGroundID) || subcat == null).
            Where(a => a.ShowGroundName.Contains(searching) || searching == null).
            OrderBy(a => filter == "name" ? a.ShowGroundName : filter == "dis" ? a.District.DistrictName : null).
            ThenByDescending(a => filter == "descname" ? a.ShowGroundName : filter == "descdisname" ? a.District.DistrictName : null).

            Include(a => a.District).Take(12).ToListAsync();


            return View(x);
        }


        public IActionResult SearchBar(string searchingFor)
        {
            return RedirectToAction("", "", new { searching = searchingFor });
        }


        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }


}