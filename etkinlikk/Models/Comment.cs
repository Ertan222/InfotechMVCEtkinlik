using System.ComponentModel.DataAnnotations;

namespace etkinlikk.Models
{
    public class Commentt
    {
        [Key]
        public int CommenttId { get; set; }
        [Required(ErrorMessage = "{0} must be filled."), Display(Name = "User")]
        public int UserrID { get; set; }
        [Required(ErrorMessage = "{0} must be filled."), Display(Name = "ShowGround"), Range(1, 9999, ErrorMessage = "{0} must be chosen")]
        public int ShowGroundID { get; set; }

        [Required(ErrorMessage = "{0} must be filled."), Display(Name = "Comment Date")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy}")]
        [DataType(DataType.Date, ErrorMessage = "Date is not in corect form")]
        public DateTime CommenttDate { get; set; }
        [Required(ErrorMessage = "{0} must be filled."), Display(Name = "Comment"), StringLength(99999, MinimumLength = 5, ErrorMessage = "{0} {2} - {1} needs to be in range .")]
        public string Content { get; set; }

        public Userr Userr { get; set; }
        public ShowGround ShowGround { get; set; }
    }
}
