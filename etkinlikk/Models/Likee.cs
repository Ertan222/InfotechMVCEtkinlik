

using System.ComponentModel.DataAnnotations;

namespace etkinlikk.Models
{
    public class Likee
    {
        [Key]
        public int LikeeID { get; set; }
        [Required(ErrorMessage = "{0} must be filled."), Display(Name = "User")]
        public int UserrID { get; set; }
        [Required(ErrorMessage = "{0} must be filled."), Display(Name = "ShowGround"), Range(1, 9999, ErrorMessage = "{0} must be chosen")]
        public int ShowGroundID { get; set; }
        [Required(ErrorMessage = "{0} must be filled."), Display(Name = "Like Date")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy}")]
        [DataType(DataType.Date, ErrorMessage = "Date is not in corect form")]
        public DateTime LikeeDate { get; set; }

        public ShowGround ShowGround { get; set; }
        public Userr Userr { get; set; }
    }
}
