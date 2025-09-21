using Microsoft.AspNetCore.Http;    
using Microsoft.AspNetCore.Mvc;
using Dapper_in_ASP.NET_CORE.Repositories;
using Dapper_in_ASP.NET_CORE.Model;
using Dapper;

namespace Dapper_in_ASP.NET_CORE.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DepartmentController : ControllerBase
    {
        private IDepartmentRepositories _departmentRepository;

        public DepartmentController(IDepartmentRepositories departmentRepository)
        {
            _departmentRepository = departmentRepository;
        }

        public IActionResult Index()
        {
            var departments = _departmentRepository.GetAllDepartmentsAsync("GetAllDepartments", null, System.Data.CommandType.StoredProcedure);
            return Ok(departments);
        }

        [HttpGet]
        public IActionResult Create()
        {

            return Ok("Create Department");
        }

        [HttpPost]
        public IActionResult Create(Department department)
        {
            if (ModelState.IsValid)
            {
                dynamic parameters = new DynamicParameters();
                parameters.Add("@name", department.Name);
                _departmentRepository.DMLDepartmentAsync("AddDepartment", parameters, System.Data.CommandType.StoredProcedure);
                return RedirectToAction("Index");
            }
            return Ok(department);
        }



    }
}
