using etkinlikk.Models;

namespace etkinlikk.ViewModel
{
    public class ShowgroundHomeViewModel
    {
        public ShowGround ShowGround { get; set; }
        public List<SubCategory> SubCategoryList { get; set; }
        public List<ShowGroundSubCategory> ShowGroundSubCategoryList { get; set; }
    }
}
