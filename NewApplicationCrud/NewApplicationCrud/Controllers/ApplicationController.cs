using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NewApplicationCrud.Model;
using NewApplicationCrud.Repository;

namespace NewApplicationCrud.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ApplicationController : ControllerBase
    {
        private readonly IApplicationRepository _applicationRepository;
        public ApplicationController(IApplicationRepository applicationRepository)
        {
            _applicationRepository = applicationRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var result = await _applicationRepository.GetAllAsync();
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById([FromRoute] int id)
        {
            var result = await _applicationRepository.GetByIdAsync(id);
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] ApplicationModel model)
        {
            var result = await _applicationRepository.CreateAsync(model);
            return Ok(result);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update([FromBody] ApplicationModel model, [FromRoute] int id)
        {
            var result = await _applicationRepository.UpdateAsync(model, id);
            return Ok(result);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            var result = await _applicationRepository.DeleteAsync(id);
            return Ok(result);
        }


    }

}
