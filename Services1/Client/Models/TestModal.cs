using System.ComponentModel.DataAnnotations;

namespace Services1.Client.Models
{

    public class TestModal
    {
        [Range(18, 80, ErrorMessage = "Age must be between 18 and 80.")]
        public int id { get; set; }
        [Required]
        public string name { get; set; }
    }
}
