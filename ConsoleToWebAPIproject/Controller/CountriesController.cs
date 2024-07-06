using ConsoleToWebAPIproject.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ConsoleToWebAPIproject.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class CountriesController : ControllerBase
    {
        [BindProperty]
        public CountryModel Country { get; set; }
        [HttpPost(" ")]
        public IActionResult Addcountry()
        {
            return Ok ( $"Name = {this.Country.Name}," 
                    + $"Population={this.Country.population}," + $"Area={this.Country.Area}");
        }
        
    }
}
