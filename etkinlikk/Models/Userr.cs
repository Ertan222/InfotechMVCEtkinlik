using etkinlikk.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;



namespace etkinlikk.Models
{
    public class Userr
    {

        [Key]
        public int UserrID { get; set; }


        [Required(ErrorMessage = "{0} must be filled"),Display(Name ="Email"), StringLength(50, MinimumLength = 6, ErrorMessage = "{0}, {2}-{1} needs to be in range"), DataType(DataType.EmailAddress, ErrorMessage = "Invalid {0}")]
        public string Emaill { get; set; }



        [Required(ErrorMessage = "{0} must be filled"), Display(Name ="Password"),StringLength(20, MinimumLength = 6, ErrorMessage = "{0}, {2}{1} needs to be in range"),  DataType(DataType.Password)]
        public string Passwordd { get; set; }

        [NotMapped, Display(Name = "Password Repeat"), DataType(DataType.Password), Compare("Passwordd", ErrorMessage = "Password and Password Repeat aren't same")]
        public string PasswordRepeatt{ get; set; }


        [Required(ErrorMessage = "{0} must be filled"), Display(Name = "Role")]
        public byte RoleeID { get; set; }

        

        public Rolee Rolee { get; set; } 

    }
}
