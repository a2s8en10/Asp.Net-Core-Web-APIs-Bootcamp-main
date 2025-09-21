using ConnectivityWithAngular.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ConnectivityWithAngular.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ConnectController : ControllerBase
    {
        private readonly IConnectRepository _connectRepository;
        public ConnectController(IConnectRepository connectRepository)
        {
            _connectRepository = connectRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllMassageAsync()
        {
            var result = await _connectRepository.GetAllMassageAsync();
            return Ok(result);
        }
    }
} 
