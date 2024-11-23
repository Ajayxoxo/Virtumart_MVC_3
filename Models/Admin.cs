using System.ComponentModel.DataAnnotations;

namespace Virtumart_MVC_3.Models
{
    public class Admin
    {
        [Key]
        [Required(ErrorMessage = "Username is Required")]
        public string Username { get; set; }    
        
        [Required(ErrorMessage = "Password is Required")]
        public string Password { get; set; }    
    }
}
