using BookStore.API.Model;
using BookStore.API.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace BookStore.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        private readonly IBookRepository _bookRepository;

        public BooksController(IBookRepository bookRepository)
        {
            _bookRepository = bookRepository;
        }

        // Get API 
        [HttpGet("")]
        public async Task<IActionResult> GetAllBooks()
        {
            var books = await _bookRepository.GetAllBooksAsync();
            return Ok(books);
        }
        // Get one item from data 
        [HttpGet("{id}")]
        public async Task<IActionResult> GetBookById([FromRoute]int id )
        {
            var books = await _bookRepository.GetBookByIdAsync(id);
            if (books == null)
            {
                return NotFound();
            }
            return Ok(books);
        }

        // POST API
        [HttpPost("")]
        public async Task<IActionResult> AddNewBooks([FromBody]BookModel bookModel)
        {
            var id = await _bookRepository.AddBookAsync(bookModel);
            return CreatedAtAction(nameof(GetBookById),new {id = id, Controller = "books"}, id);
        }

        // PUT API
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateBook([FromBody] BookModel bookModel, [FromRoute]int id)
        {
            await _bookRepository.UpdateBookAsync(id ,bookModel);
            return Ok();
        }

        // PATCH API
        [HttpPatch("{id}")]
        public async Task<IActionResult> UpdateBookPatch([FromBody] JsonPatchDocument bookModel, [FromRoute] int id)
        {
            await _bookRepository.UpdateBookPatchAsync(id, bookModel);
            return Ok();
        }

        // DELETE API
        [HttpDelete("{id}")]
        public async Task<IActionResult> deletebook([FromRoute] int id)
        {
            await _bookRepository.DeleteBooksAsync(id);
            return Ok();
        }
    }
}
