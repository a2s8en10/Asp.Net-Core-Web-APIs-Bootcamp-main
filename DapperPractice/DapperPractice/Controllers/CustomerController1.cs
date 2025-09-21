using Dapper;
using DapperPractice.Models;
using Microsoft.AspNetCore.Mvc;
using System.Data;

namespace DapperPractice.Controllers
{
    public class CustomerController : Controller
    {
        private readonly IDbConnection _dbConnection;
        public CustomerController(IDbConnection dbConnection)
        {
            _dbConnection = dbConnection;
        }

        public IActionResult Index()
        {
            IEnumerable<Customer> customers = _dbConnection.Query<Customer>("SELECT * FROM Customers");
            return View(customers);
        }

        public IActionResult Details(int id)
        {
            Customer customers = _dbConnection.QuerySingleOrDefault<Customer>("SELECT * FROM Customers WHERE Id = @Id", new { Id = id });
            if(customers == null)
            {
                return NotFound();
            }
            return View(customers);
        }

        // Create first and then second http method
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Customer customer)
        {
            _dbConnection.Execute("INSERT INTO Customers (Name, Email) VALUES (@Name, @Email)", customer);

            return RedirectToAction("Index");
        }

        // Edit first and then second http method
        public IActionResult Edit(int id)
        {
            Customer customer = _dbConnection.QuerySingleOrDefault<Customer>("SELECT * FROM Customer WHERE Id = @Id", new { Id = id });
            if (customer == null)
            {
                return NotFound();
            }
            return View(customer);
        }

        [HttpPost]
        public IActionResult Edit(Customer customer)
        {
            _dbConnection.Execute("UPDATE Customers SET Name = @Name, Email = @Email WHERE Id = @Id", customer);
            return RedirectToAction("Index");
        }

        public IActionResult Delete(int id)
        {
            Customer customer = _dbConnection.QuerySingleOrDefault<Customer>("SELECT * FROM Customer WHERE Id = @Id", new { Id = id });
            if (customer == null)
            {
                return NotFound();
            }
            return View(customer);
        }

        [HttpPost]
        public IActionResult DeleteConfirmed(int id)
        {
            _dbConnection.Execute("DELETE FROM Customers WHERE Id = @Id", new { Id = id });
            return RedirectToAction("Index");
        }


    }
}
