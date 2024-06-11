using Microsoft.AspNetCore.Mvc;
namespace ConsoleToWebAPIproject.Controller
{
    [ApiController]
    [Route("Test/[action]")]
    public class Testcontroller : ControllerBase
    {
       public string get ()
        {
            return "hello from get";
        }
        public string get1()
        {
            return "hello from get1";
        }


    }
}
