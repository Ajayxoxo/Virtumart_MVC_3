using System.ComponentModel.DataAnnotations;

namespace Virtumart_MVC_3.Models
{
    public class User
    {
        [Key]
        [Required(ErrorMessage = "Username is required")]
        public string Username { get; set; }

        [Required(ErrorMessage = "Password is required")]
        public string Password { get; set; }
    }
}
