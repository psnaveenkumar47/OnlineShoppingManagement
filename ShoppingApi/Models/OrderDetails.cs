    using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ShoppingApi.Models
{
    public class OrderDetails
    {
        [Key]
        public int OrderID { get; set; }
        [ForeignKey("Product")]
        public  int ProductID { get; set; }
        public Product? Product { get; set; }
        public DateTime OrderedDate { get; set; }
        public int TotalQuantity { get; set; }  
        public int Total { get; set; }
        [ForeignKey("User")]
        public int UserID { get; set; }
        public User? User { get; set; }  

    }
}
