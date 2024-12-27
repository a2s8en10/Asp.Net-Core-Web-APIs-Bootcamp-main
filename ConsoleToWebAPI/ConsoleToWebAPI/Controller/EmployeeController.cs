using ConsoleToWebAPI.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace ConsoleToWebAPI.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        
        // Specific type
        [Route ("")]
        public List<EmployeeModel> GetEmployees()
        {
            return new List<EmployeeModel>()
            {
                new EmployeeModel () {Id = 1, Name = "Employee 1"},
                new EmployeeModel () {Id = 2, Name = "Employee 2"}
            };
        }

        // IActionResult 
        [Route("{id}")]
        public IActionResult GetEmployees(int id)
        {
            if (id == 0) 
            {
                return NotFound();
            }
            return Ok(new List<EmployeeModel>()
            {
                new EmployeeModel () {Id = 1, Name = "Employee 1"},
                new EmployeeModel () {Id = 2, Name = "Employee 2"}
            });
        }

        // ActionResult <T>
        [Route("{id}/basic")]

        public ActionResult<EmployeeModel> GetEmployeeBasicDetaile(int id)
        {
            if(id == 0)
            {
                return NotFound();
            }
            return new EmployeeModel() { Id = 1, Name = "Employee 1" };
        }
    }
}
