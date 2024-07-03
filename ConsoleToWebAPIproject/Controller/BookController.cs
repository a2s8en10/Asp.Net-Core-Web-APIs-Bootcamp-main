using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ConsoleToWebAPIproject.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookController : ControllerBase
    {
        [Route("{id:int:min(10):max(999):minlength(2):maxlength(3)}")]
        public string Getbyid(int id)
        {
            return "hello int " + id;
        }
        [Route("{id:length(4):Range(999,9999)}")]
        public string Getbyidstring(string id)
        {
            return "hello string " + id;
        }
        [Route("{id:alpha:length(5)}")]
        public string stringid(string id)
        {
            return "hello stringid " + id;
        }
        [Route("{id:regex(Anurag|Relax(Sahu|Anurag))}")]
        public string regexid(string id)
        {
            return "hello regexid " + id;
        }
    }
}
