using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ConsoleToWebAPI.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        [Route("{id:int:min(10):max(15)}")]
        public string Getbyid(int id)
        {
            return "int is : " + id;
        }

        [Route("{id}")]
        public string Getbystring(string id)
        {
            return "string is : "+ id;
        }

        //[Route("{id:minLength(5):maxLength(10)}")]
        //public string GetbyLength(string id)
        //{
        //    return "length is : " + id;
        //}

        [Route("{id:length(3):alpha}")]
        public string Getbyalpha(string id)
        {
            return "alpha is : " + id;
        }
        [Route("{id:regex(a(b|c)):length(5):alpha}")]
        public string Getbyregex(string id)
        {
            return "regex is : " + id;
        }
    }
}
