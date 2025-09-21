using API_CRUD.Model;
using API_CRUD.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace API_CRUD.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ApiController : ControllerBase
    {
        private readonly IApiRepository _apiRepository;
        public ApiController(IApiRepository apiRepository)
        {
            _apiRepository = apiRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var result = await _apiRepository.GetAllAsync();
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById([FromRoute] int id)
        {
            var result = await _apiRepository.GetByIdAsync(id);
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> Add([FromBody] ApiModel model)
        {
            var result = await _apiRepository.AddAsync(model);
            return Ok(result);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update([FromBody] ApiModel model, [FromRoute] int id)
        {
            await _apiRepository.UpdateAsync(model, id);
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            var result = await _apiRepository.DeleteAsync(id);
            if (id == null)
            {
                return NotFound();
            }
            return Ok(result);
        }
    }
}
