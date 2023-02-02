using System.ComponentModel.DataAnnotations;

namespace ShoppingMVC.Models
{
    public class UserData
    {
        [Key]
        public int UserID { get; set; }
        [Required]
        public string? FirstName { get; set; }
        [Required]
        public string? LastName { get; set; }
        [Required]
        public string? Email { get; set; }
        [Required]
        [MinLength(10, ErrorMessage = "Please check the length of mobile number"),MaxLength(10,ErrorMessage = "Please check the length of mobile number")]
        public long MobileNumber { get; set; }
        [Required]
        public string Address { get; set; }
        [Required]
        [MaxLength(15, ErrorMessage = "Length of username should be less than 15 characters"), MinLength(5, ErrorMessage = "Length of username should be greater than 5 characters")]
        public string UserName { get; set; }
        [Required]
        [MinLength(8, ErrorMessage = "Length of Password should be greater than 8 characters")]
        public string Password { get; set; }
       
    }
}
