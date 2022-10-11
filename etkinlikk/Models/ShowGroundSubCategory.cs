using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace etkinlikk.Models
{
    public class ShowGroundSubCategory
    {
        [Key]

        public int ShowGroundSubCategoryID { get; set; }
        [Required(ErrorMessage = "{0} must be filled."), Display(Name = "ShowGround"), Range(1, 10000, ErrorMessage = "{0} must be chosen")]
        public int ShowGroundID { get; set; }
        [Required(ErrorMessage = "{0} must be filled."), Display(Name = "SubCategory"), Range(1, 1000, ErrorMessage = "{0} must be chosen")]
        public int SubCategoryID { get; set; }

        public SubCategory SubCategory { get; set; }

        public ShowGround Showground { get; set; }

    }
}
