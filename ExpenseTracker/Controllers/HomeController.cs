using ExpenseTracker.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace ExpenseTracker.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Expense()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Expense(Expense Expense)
        {
            if(ModelState.IsValid)
            {
                string item = Expense.Item;
                double value = Expense.Value;
                string paymentmethod = Expense.PaymentMethod;
                string description = Expense.Description;

                SaveExpensesDB.saveExpensesDB(item, value, paymentmethod, description);
                return RedirectToAction("Index");
            }
            else
            {
                return View();
            }
        }

        public IActionResult SeeExpenses()
        {
            List<Expense> expenses = SeeExpensesDB.seeExpensesDB();
            double totalExpenses = expenses.Sum(exp => exp.Value); // Calcular o total das despesas
            ViewBag.TotalExpenses = totalExpenses; // Passar o total para a View
            return View(SeeExpensesDB.seeExpensesDB());
        }

        [HttpPost]
        public IActionResult DeleteExpense(int Id)
        {
            // Chama seu método para excluir a despesa do banco de dados
            DeleteExpenseDB.deleteExpenseDB(Id);

            // Redireciona de volta para a lista de despesas
            return RedirectToAction("SeeExpenses");
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
