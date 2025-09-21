using Create_CRUD_With_Web_Api.Model;
using Create_CRUD_With_Web_Api.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Create_CRUD_With_Web_Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class User1Controller : ControllerBase
    {
        private readonly IUser1Repository _user1Repository;

        public User1Controller(IUser1Repository user1Repository)
        {
            _user1Repository = user1Repository;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllUsers()
        {
            var users = await _user1Repository.GetAllUsersAsync();
            return Ok(users);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById([FromRoute]int id)
        {
            var users = await _user1Repository.GetUserByIdAsync(id);
            if(users == null)
            {
                return NotFound();
            }
            return Ok(users);

        }

        [HttpPost("")]
        public async Task<IActionResult> AddNewUser([FromBody]User1 user1)
        {
            var id = await _user1Repository.AddNewUserAsync(user1);
            return CreatedAtAction(nameof(GetById), new { Id = id, Controller = "User1" }, id);
        }
    }
}
 