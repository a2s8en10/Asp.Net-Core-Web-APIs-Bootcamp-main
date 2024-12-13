using Microsoft.AspNetCore.Mvc;

namespace ConsoleToWebAPI.Controller
{
    [ApiController]
    [Route("test/[action]")]
    public class Testcontroller : ControllerBase
    {
        public string Get()
        {
            return "hello Relax";
        }
        public string Get1()
        {
            return "hello Pride";
        }
    }
}
