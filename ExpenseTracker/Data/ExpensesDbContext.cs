using ExpenseTracker.Models;
using Microsoft.EntityFrameworkCore;

namespace ExpenseTracker.Data
{
    public class ExpensesDbContext(DbContextOptions<ExpensesDbContext> options) : DbContext(options)
    {
        public DbSet<Expense> Expenses { get; set; }
    }
}
