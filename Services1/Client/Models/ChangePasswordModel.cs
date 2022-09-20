using System.ComponentModel.DataAnnotations;

namespace Services1.Client.Models
{
    public class ChangePasswordModel
    {
        [Required(ErrorMessage = "Please Enter Old Password")]
        [MinLength(8, ErrorMessage = "Enter a Password withing 8-16 Chatacters")]
        [MaxLength(16, ErrorMessage = "Enter a Password withing 8-16 Chatacters")]
        public string opassword { get; set; }
        [Required(ErrorMessage = "Please Enter New Password")]
        [MinLength(8, ErrorMessage = "Enter a Password withing 8-16 Chatacters")]
        [MaxLength(16, ErrorMessage = "Enter a Password withing 8-16 Chatacters")]
        public string npassword { get; set; }
        [Required(ErrorMessage = "Please Enter Confirm Password")]
        [MinLength(8, ErrorMessage = "Enter a Password withing 8-16 Chatacters")]
        [MaxLength(16, ErrorMessage = "Enter a Password withing 8-16 Chatacters")]
        public string cpassword { get; set; }
    }
}
