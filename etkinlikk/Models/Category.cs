using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace etkinlikk.Models
{
    public class Category
    {
        public int CategoryID { get; set; }

        [Required(ErrorMessage = "{0} must be filled."), Display(Name = "Category"), StringLength(40, MinimumLength = 3, ErrorMessage = "{0} {2} - {1} needs to be in range .")]
        public string CategoryName { get; set; }
    }
}
