using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace etkinlikk.Models
{
    public class Rolee
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.None)]
        public byte RoleeID { get; set; }

        [Required(ErrorMessage ="{0} must be filled"), StringLength(20, MinimumLength = 3, ErrorMessage = "{0, {2}-{1} needs to be in range}"), Display(Name = "Role")]
        public string RoleeName { get; set; }

    }
}