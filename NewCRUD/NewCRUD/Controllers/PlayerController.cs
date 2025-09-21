using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NewCRUD.Model;
using NewCRUD.Repository;
using System.Runtime.Intrinsics.X86;

namespace NewCRUD.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PlayerController : ControllerBase
    {
        private readonly IPlayerRepository _playerRepository;
        public PlayerController(IPlayerRepository playerRepository)
        {
            _playerRepository = playerRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllPlayer()
        {
            var result = await _playerRepository.GetAllPlayerAsync();
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetByIdPlayer([FromRoute] int id)
        {
            var result = await _playerRepository.GetByIdPlayerAsync(id);
            if (result == null)
                return NotFound();

            return Ok(result);
        }

        [HttpPost("")]
        public async Task<IActionResult> AddNewUser([FromBody] PlayerModel player)
        {
            var result = await _playerRepository.AddNewPlayerAsync(player);
            return CreatedAtAction(nameof(GetByIdPlayer), new { id = result.Id }, result);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePlayer([FromRoute] int id)
        {

            await _playerRepository.DeletePlayerAsync(id);
            return Ok();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdatePlayer([FromBody] PlayerModel player, [FromRoute] int id)
        {
            await _playerRepository.UpdatePlayerAsync(player, id);
            return Ok();
        }
    }
}
