using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ShoppingMVC.Models
{
    public class CategoryData
    {
        [Key]
        public int CategoryID { get; set; }
        
        [Required]
        public string CategoryName { get; set; }    
    }
}
