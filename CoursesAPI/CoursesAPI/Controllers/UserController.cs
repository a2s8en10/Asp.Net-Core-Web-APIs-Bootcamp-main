using CoursesAPI.Model;
using Dapper;
using Microsoft.AspNetCore.Mvc;
using System.Data;

namespace CoursesAPI.Controllers
{
    public class UserController : Controller
    {
        private readonly IDbConnection _dbConnection;

        public UserController(IDbConnection dbConnection)
        {
            _dbConnection = dbConnection;
        }

        public IActionResult Index()
        {
            IEnumerable<UserModel> UserModels = _dbConnection.Query<UserModel>("SELECT * FROM UserModels");
            return View(UserModels);
        }
        public IActionResult Details(int id)
        {
            UserModel? UserModel = _dbConnection.QuerySingleOrDefault<UserModel>("SELECT * FROM UserModels WHERE Id = @Id", new { Id = id });
            if (UserModel == null)
            {
                return NotFound();
            }
            return View(UserModel);
        }
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]

        public IActionResult Create(UserModel UserModel)
        {
            _dbConnection.Execute("INSERT INTO UserModels (Name, Email) VALUES (@Name, @Email)", UserModel);
            return RedirectToAction("Index");
        }

        public IActionResult Edit(int id)
        {
            UserModel? UserModel = _dbConnection.QuerySingleOrDefault<UserModel>("SELECT * FROM UserModels WHERE Id = @Id", new { Id = id });
            if (UserModel == null)
            {
                return NotFound();
            }
            return View(UserModel);
        }
        [HttpPost]
        public IActionResult Edit(UserModel UserModel)
        {
            _dbConnection.Execute("UPDATE UserModels SET Name = @Name, Email = @Email WHERE Id = @Id", UserModel);
            return RedirectToAction("Index");
        }

        public IActionResult Delete(int id)
        {
            UserModel? UserModel = _dbConnection.QuerySingleOrDefault<UserModel>("SELECT * FROM UserModels WHERE Id = @Id", new { Id = id });
            if (UserModel == null)
            {
                return NotFound();
            }
            return View(UserModel);
        }

        [HttpPost]
        public IActionResult DeleteConfirmed(int id)
        {
            _dbConnection.Execute("DELETE FROM UserModels WHERE Id = @Id", new { Id = id });
            return RedirectToAction("Index");
        }
    }
}
