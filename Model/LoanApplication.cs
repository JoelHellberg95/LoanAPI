using LoanAPI.Enum;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace LoanAPI.Model
{
    public class LoanApplication
    {
        public int Id { get; set; }
        public User Borrower { get; set; }
        [Range(1000, double.MaxValue, ErrorMessage = "Amount cannot be less than 1000")]
        public double Amount { get; set; }

        [JsonConverter(typeof(JsonStringEnumConverter))]
        public LoanStatus Status { get; set; }
        public DateTime Date { get; set; }
    }
}
