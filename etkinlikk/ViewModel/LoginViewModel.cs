using System.ComponentModel.DataAnnotations;
namespace etkinlikk.ViewModel
{
    public class LoginViewModel
    {

        [Required(ErrorMessage = "{0} must be filled"), Display(Name = "Email"), StringLength(50, MinimumLength = 6, ErrorMessage = "{0}, {2}{1} needs to be in range"), DataType(DataType.EmailAddress, ErrorMessage = "Invalid {0}")]
        public string Emaill { get; set; }



        [Required(ErrorMessage = "{0} must be filled"), Display(Name = "Password"), StringLength(20, MinimumLength = 6, ErrorMessage = "{0}, {2}{1} needs to be in range"), DataType(DataType.Password)]
        public string Passwordd { get; set; }

    }
}
