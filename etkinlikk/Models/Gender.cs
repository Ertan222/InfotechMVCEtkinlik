using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace etkinlikk.Models
{

    public class Gender
    {
        [Key]
        public int GenderID { get; set; }
        [Required(ErrorMessage = "{0} must be filled."), Display(Name = "Gender"), StringLength(40, MinimumLength = 3, ErrorMessage = "{0} {2} - {1} needs to be in range .")]
        public string GenderName { get; set; }
    }
}
