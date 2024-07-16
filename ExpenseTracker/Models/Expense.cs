using System.ComponentModel.DataAnnotations;

namespace ExpenseTracker.Models
{
    public class Expense
    {
        public int Id { get; set; }
        public decimal Price { get; set; }
        [Required] public string? Description { get; set; }
    }
}
