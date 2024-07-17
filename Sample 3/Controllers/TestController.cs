using Microsoft.AspNetCore.Mvc;

namespace Sample_3.Controller
{
    [ApiController]
    [Route("Test")]
    public class TestController : ControllerBase
    {
        public string get()
        {
            return "Anurag";
        }
    }
}
