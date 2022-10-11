using System.ComponentModel.DataAnnotations;

namespace etkinlikk.Models
{
    public class District
    {
        [Key]
        public int DistrictID { get; set; }

        [Required(ErrorMessage = "{0} must be filled."), Display(Name = "District"), StringLength(40, MinimumLength = 3, ErrorMessage = "{0} {2} - {1} needs to be in range .")]
        public string DistrictName { get; set; }

        [Required(ErrorMessage = "{0} must be filled."), Display(Name = "City"), Range(1, 100, ErrorMessage = "{0} must be chosen")]
        public int CityID { get; set; }

        public City City { get; set; }

    }
}
