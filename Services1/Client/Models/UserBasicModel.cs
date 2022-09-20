using System.ComponentModel.DataAnnotations;

namespace Services1.Client.Models
{
    public class UserBasicModel
    {
        [Required(ErrorMessage = "Please enter User First Name")]
        public string fname { get; set; }
        [Required(ErrorMessage = "Please enter User Last Name")]
        public string lname { get; set; }
        [Required(ErrorMessage = "Please enter User Display Name")]
        public string dname { get; set; }
        [Required(ErrorMessage = "Please enter User NIC")]
        [MinLength(10, ErrorMessage = "id number must have 10 to 12 characters")]
        [MaxLength(12, ErrorMessage = "id number must have 10 to 12 characters")]
        public string nic { get; set; }
    }
}
