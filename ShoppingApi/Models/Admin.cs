using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace ShoppingApi.Models
{
    public class Admin
    {
        [Key]
        public int AdminID { get; set; }
        [Required]
        public string? FirstName { get; set; }
        [Required]
        public string? LastName { get; set; }
        [Required]
        public string? Email { get; set; }
        [Required]
        public long MobileNumber { get; set; }
        [Required]
        [MaxLength(15,ErrorMessage="Length of username should be less than 15 characters"), MinLength(5,ErrorMessage = "Length of username should be greater than 5 characters")]
        public string UserName { get; set; }
        [Required]
        [MinLength(8,ErrorMessage ="Length of Password should be greater than 8 characters")]
        public string Password { get; set; }

    }
}
