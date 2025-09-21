using Auth.Data;
using Auth.Model;
using Auth.Model.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Auth.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly ApplicationDbContext _dbContext;
        public EmployeeController(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        [HttpGet]
        public IActionResult getEmployee()
        {
            var allEmployee = _dbContext.Employees.ToList();
            return Ok(allEmployee);
        }

        [HttpGet]
        [Route("{id:guid}")]
        public IActionResult getByIdEmployee(Guid id)
        {
            var employee = _dbContext.Employees.Find(id);

            if(employee is null)
            {
                return NotFound("Employee not found");
            }

            return Ok(employee);
        }

        [HttpPost]
        public IActionResult AddEmployee(Employee addEmployee)
        {
            var emp = new Employee
            {
                Email = addEmployee.Email,
                Name = addEmployee.Name,
                Phone = addEmployee.Phone,
                Salary = addEmployee.Salary,
            };

            _dbContext.Employees.Add(emp);
            _dbContext.SaveChanges();

            return Ok(emp);
        }

        [HttpPut]
        [Route("{id:guid}")]
        public IActionResult UpdateEmployee(Guid id , Employee UpdateEmployee)
        {
            var employee = _dbContext.Employees.Find(id);

            if(employee is null)
            {
                return NotFound("Employee not found");
            }

            employee.Name = UpdateEmployee.Name;
            employee.Email = UpdateEmployee.Email;
            employee.Phone = UpdateEmployee.Phone;
            employee.Salary = UpdateEmployee.Salary;

            _dbContext.SaveChanges();
            return Ok(employee);
        }

        [HttpDelete]
        [Route("{id:guid}")]
        public IActionResult DeleteEmployee(Guid id)
        {
            var employee = _dbContext.Employees.Find(id);
            if(employee is null)
            {
                return NotFound("Employee not found");
            }

            _dbContext.Employees.Remove(employee);
            _dbContext.SaveChanges();

            return Ok();
        }
    }
}
