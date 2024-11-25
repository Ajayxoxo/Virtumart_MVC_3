using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Virtumart_MVC_3.Models
{
    public class User
    {

        [Key]
        public int userid { get; set; } 

        [Required(ErrorMessage = "Username is required")]
        public string Username { get; set; }

        [Required(ErrorMessage = "Password is required")]
        public string Password { get; set; }

        [Required(ErrorMessage = "Password is required")]
        [Compare("Password", ErrorMessage = "Password and Confirm Password must match")]
        [NotMapped]
        public string CPassword { get; set; }

        [Required(ErrorMessage ="Email is Required")]
        [EmailAddress(ErrorMessage = "Entered Email is not Invaild")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Phone No is Required")]
        [RegularExpression(@"^\+?[0-9]{10,15}$", ErrorMessage = "Enter a valid phone number")]
        public string Phone { get; set; }
    }
}
