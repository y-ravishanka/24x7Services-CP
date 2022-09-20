using System.ComponentModel.DataAnnotations;

namespace Services1.Client.Models
{
    public class UserResetPasswordModel
    {
        [Required(ErrorMessage = "Please Enter Password")]
        [MinLength(8, ErrorMessage = "Enter a Password withing 8-16 Chatacters")]
        [MaxLength(16, ErrorMessage = "Enter a Password withing 8-16 Chatacters")]
        public string password { get; set; }
        [Required(ErrorMessage = "Please Enter Confirm Password")]
        [MinLength(8, ErrorMessage = "Enter a Password withing 8-16 Chatacters")]
        [MaxLength(16, ErrorMessage = "Enter a Password withing 8-16 Chatacters")]
        public string cpassword { get; set; }
    }
}
