using Microsoft.EntityFrameworkCore.Infrastructure;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Virtumart_MVC_3.Models;

namespace VirtuMart_MVC_3.Models
{
    public class ImageUrl
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int imageid { get; set; } 

        [Required]
        public int productid { get; set; } 

        [Required]
        [StringLength(500)]
        public string imageurl { get; set; } 

        [ForeignKey("productid")]
        [Required]
        public IProduct Product { get; set; }
    }
}
