using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace etkinlikk.Models
{
    public class ShowGround
    {
        public int ShowGroundID { get; set; }

        [Required(ErrorMessage = "{0} must be filled."), Display(Name = "ShowGround"), StringLength(100, MinimumLength = 3, ErrorMessage = "{0} {2} - {1} needs to be in range .")]
        public string ShowGroundName { get; set; }

        public int? Capacity { get; set; }
        //public string Coordinate { get; set; }

        [Required(ErrorMessage = "{0} must be filled."), Display(Name = "Address"), StringLength(400, MinimumLength = 10, ErrorMessage = "{0} {2} - {1} needs to be in range .")]
        public string Address { get; set; }

        [Required(ErrorMessage = "{0} must be filled."), Display(Name = "District"), Range(1, 99, ErrorMessage = "{0} must be chosen")]
        public int DistrictID { get; set; }

        public District District { get; set; }
    }
}
