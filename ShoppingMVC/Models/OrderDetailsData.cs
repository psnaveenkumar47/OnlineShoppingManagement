using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ShoppingMVC.Models
{
    public class OrderDetailsData
    {
        [Key]
        public int OrderID { get; set; }
        [ForeignKey("Product")]
        public  int ProductID { get; set; }
        public ProductData Product { get; set; }
        public DateTime OrderedDate { get; set; }
        public int TotalQuantity { get; set; }  
        public int Total { get; set; }
        [ForeignKey("User")]
        public int UserID { get; set; }
        public UserData User { get; set; }  

    }
}
