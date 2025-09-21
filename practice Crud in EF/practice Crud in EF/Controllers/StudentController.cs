using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using practice_Crud_in_EF.Model;
using practice_Crud_in_EF.Repository;
using System.Threading.Tasks;

namespace practice_Crud_in_EF.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        private readonly IStudentRepository _studentRepository;
        public StudentController(IStudentRepository studentRepository)
        {
            _studentRepository = studentRepository;
        }

        [HttpGet("")]
        public async Task<IActionResult> GetAllDetail()
        {
            var result = await _studentRepository.GetStudentDetail();
            return Ok(result);
        }

        [HttpGet("{id}")]

        public async Task<IActionResult> GetStudentById([FromRoute]int id)
        {
            var result = await _studentRepository.GetStudentByIdAsync(id);
            if(result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }

        [HttpPost("")]
        public async Task<IActionResult> AddStudent([FromBody] StudentModel studentModel)
        {
            var id = await _studentRepository.AddStudentAsync(studentModel);
            return  CreatedAtAction(nameof(GetStudentById), new { Id = id, Controller = "student" }, id);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateStudent([FromBody] StudentModel studentModel, [FromRoute]int id)
        {
            await _studentRepository.UpadteStudentAsync(studentModel, id);
            return Ok();
        }
    }
}
