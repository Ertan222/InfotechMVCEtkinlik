using etkinlikk.Models;

namespace etkinlikk.ViewModel
{
    public class HomeViewModel
    {
        public List<Category> CategoryList { get; set; }
        public List<SubCategory> SubCategoryList { get; set; }
        public List<ShowGround> ShowgroundsList { get; set; }
        public List<City> CitiesList { get; set; }
        public List<District> DistrictsList { get; set; }
        public int? SelectedCategoryID { get; set; }
        public SubCategory SelectedSubCategory { get; set; }
        public int? SelectedCityID { get; set; }


    }
}
