using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        private readonly ExpenseDbContext _context;
        public HomeController(ILogger<HomeController> logger, ExpenseDbContext context)
        {
            _logger = logger;
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult AboutUs()
        {
            return View();
        }

        public ActionResult MyForm() 
        {
            return View();
        }

        public IActionResult Expenses() 
        { 
            var allExpenses = _context.Expenses.ToList(); 
            return View(allExpenses);
        }

        public IActionResult CreateEditExpense(int? id) //if we don't null id we will get an errror
        {
            if (id == null) 
            {
                var expenseInDb = _context.Expenses.SingleOrDefault(x => x.Id == id);
                return View(expenseInDb);
            }
            

            return View();
        }

        public IActionResult DeleteExpense(int id) // we have to pass the id 
        {
            var expenseInDb = _context.Expenses.SingleOrDefault(x => x.Id == id); //it will hold that variable
            _context.Expenses.Remove(expenseInDb);
            _context.SaveChanges(); 

            return RedirectToAction("Expenses");
        }

        public IActionResult CreateEditExpenseForm(Expense model) // model will hold the value
        {
            if (model.Id == 0)
            {
                //Add something
                _context.Expenses.Add(model); //to specify the model in the database

            }
            else 
            {
                //update the existing expense
                _context.Expenses.Update(model);

            }


            _context.SaveChanges();
            return RedirectToAction("Expenses");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
