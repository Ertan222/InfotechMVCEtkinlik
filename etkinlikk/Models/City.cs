using System.ComponentModel.DataAnnotations;

namespace etkinlikk.Models
{
    public class City
    {
        [Key]
        public int CityID { get; set; }

        [Required(ErrorMessage = "{0} must be filled."), Display(Name = "City"), StringLength(40, MinimumLength = 3, ErrorMessage = "{0} {2} - {1} needs to be in range .")]
        public string CityName { get; set; }
    }
}
