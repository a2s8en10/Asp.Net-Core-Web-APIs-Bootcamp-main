using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ConsoleApp1.Controller
{
    [ApiController]
    [Route("Test")]
    public class TestController : ControllerBase
    {
        public string getall()
        {
            return "Get all";
        }
       
    }
}
