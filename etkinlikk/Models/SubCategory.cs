using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace etkinlikk.Models
{
    public class SubCategory
    {
        public int SubCategoryID { get; set; }
        [Required(ErrorMessage = "{0} must be filled."), Display(Name = "SubCategory"), StringLength(40, MinimumLength = 3, ErrorMessage = "{0} {2} - {1} needs to be in range.")]
        public string SubCategoryName { get; set; }

        [Required(ErrorMessage = "{0} must be filled."), Display(Name = "Category"), Range(1, 99, ErrorMessage = "{0} must be chosen")]
        public int CategoryID { get; set; }

        public Category Category { get; set; }
    }
}
