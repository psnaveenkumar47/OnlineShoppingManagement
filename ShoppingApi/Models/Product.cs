using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ShoppingApi.Models
{
    public class Product
    {
        [Key]
        public int ProductID { get; set; }
        [Required]
        public string? ProductName { get; set; }
        [Required]
        [StringLength(100)]
        public string? ProductDescription { get; set; }
        [Required]
        public int ProductPrice { get; set; }

        public string? ProductImg1 { get; set; }
        [ForeignKey("Category")]
 
        public int CategoryID { get; set; }
        public Category? Category { get; set; }


    }
}
