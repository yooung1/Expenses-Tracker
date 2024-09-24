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
            List<Expense> expenses = SeeExpensesDB.seeExpensesDB(); // instancia pra pegar os valores e somar
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

        public IActionResult EditExpense(int id)
        {
            // Recupera a despesa do banco de dados pelo ID
            Expense expense = SeeExpensesDB.seeSpecificExpenseDB(id);
            if (expense == null)
            {
                return NotFound(); // Retorna 404 se a despesa não for encontrada
            }
            return View(expense); // Passa a despesa para a view
        }


        [HttpPost]
        public IActionResult EditExpense(Expense expense)
        {
            if (ModelState.IsValid)
            {
                // Atualiza a despesa no banco de dados
                UpdateExpensesDB.UpdateExpenseDB(expense); // Você deve implementar esse método
                return RedirectToAction("SeeExpenses"); // Redireciona para a lista de despesas
            }
            return View(expense); // Retorna a view com a despesa se o modelo não for válido
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
