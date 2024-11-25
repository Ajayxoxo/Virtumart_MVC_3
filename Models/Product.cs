using System.ComponentModel.DataAnnotations;

namespace Virtumart_MVC_3.Models
{
    public class Product
    {
        [Key]
        public int productid { get; set; }  

        [Required(ErrorMessage="Name is required")]
        public string productname { get; set; }


        [Required(ErrorMessage="Description is required")]
        public string productdes { get; set; }


        [Required(ErrorMessage="Price is required")]
        public decimal price { get; set; }


        [Required(ErrorMessage="Quantity is required")]
        public decimal quantity { get; set; }


        public decimal discount { get; set; }  

        public DateTime? updatedAt{ get; set; }  
    }
}
