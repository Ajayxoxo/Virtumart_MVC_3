using Microsoft.EntityFrameworkCore.Infrastructure;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace VirtuMart_MVC_3.Models
{
    public class ImageUrl
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ImageId { get; set; } 

        [Required]
        public int ProductId { get; set; } 

        [Required]
        [StringLength(500)]
        public string ImageUrlPath { get; set; } 

        [ForeignKey("ProductId")]
        public ProductInfo ProductInfo { get; set; }
    }
}
