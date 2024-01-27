using System.ComponentModel.DataAnnotations;

namespace LoanAPI.Model
{
    public class User
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "First name is required")]
        public string FirstName { get; set; }
        [Required(ErrorMessage = "Last name is required")]
        public string LastName { get; set; }
        [Range(1000, double.MaxValue, ErrorMessage = "Income cannot be less than 1000")]
        public decimal Income { get; set; }
    }
}
