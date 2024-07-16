using ExpenseTracker.Data;
using ExpenseTracker.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace ExpenseTracker.Controllers
{
    public class HomeController(ILogger<HomeController> logger, ExpensesDbContext context) : Controller
    {
        private readonly ILogger<HomeController> _logger = logger;

        private readonly ExpensesDbContext _context = context;

        public IActionResult Index()
        {
            List<Expense> allExpenses = [.. _context.Expenses];
            decimal totalExpenses = allExpenses.Sum(x => x.Price);
            ViewBag.Expenses = totalExpenses;
            return View(allExpenses);
        }

        public IActionResult CreateEditExpense(int? id)
        {
            if (id != null)
            {
                Expense? expense = _context.Expenses.SingleOrDefault(x => x.Id == id);
                return View(expense);
            }
            Console.WriteLine("creating/edit");
            return View();
        }

        public IActionResult DeleteExpense(int id)
        {
            Expense? expense = _context.Expenses.SingleOrDefault(x => x.Id == id);
            if (expense != null)
            {
                _context.Expenses.Remove(expense);
                _context.SaveChanges();
            }
            return RedirectToAction("Index");
        }

        public IActionResult CreateEditExpenseForm(Expense model)
        {
            if (model.Id == 0)
            {
                _context.Expenses.Add(model);
            }
            else
            {
                _context.Expenses.Update(model);
            }
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
