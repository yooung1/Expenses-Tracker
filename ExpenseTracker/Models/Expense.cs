using System.ComponentModel.DataAnnotations;

namespace ExpenseTracker.Models
{
    public class Expense
    {
        public int Id { get; set; }
        [Required]
        public string? Item { get; set; }
        [Required]
        public double Value { get; set; }
        [Required]
        public string? PaymentMethod { get; set; }
        [Required]
        public string? Description {  get; set; }
    }
}
