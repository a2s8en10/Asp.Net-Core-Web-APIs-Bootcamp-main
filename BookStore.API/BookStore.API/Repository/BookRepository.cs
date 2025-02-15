using AutoMapper;
using BookStore.API.Data;
using BookStore.API.Model;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookStore.API.Repository
{
    public class BookRepository : IBookRepository
    {
        private readonly BookStoreContext _context;
        private readonly IMapper _mapper;

        public BookRepository(BookStoreContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }


        // Get API 
        public async Task<List<BookModel>> GetAllBooksAsync()
        {
            //var records = await _context.Books.Select(x => new BookModel()
            //{
            //    Id = x.Id,
            //    Title = x.Title,
            //    Description = x.Description,
            //}).ToListAsync();
            //return records;

            var records = await _context.Books.ToListAsync();
            return _mapper.Map<List<BookModel>>(records);
        }

        // Get one item from data 
        public async Task<BookModel> GetBookByIdAsync(int bookId)
        {
            //var records = await _context.Books.Where(x => x.Id == bookId).Select(x => new BookModel()
            //{
            //    Id = x.Id,
            //    Title = x.Title,
            //    Description = x.Description,
            //}).FirstOrDefaultAsync();
            //return records;

            var book = await _context.Books.FindAsync(bookId);
            return _mapper.Map<BookModel>(book);
        }

        // POST API
        public async Task<int> AddBookAsync(BookModel bookModel)
        {
            //var book = new Books()
            //{
            //    Title = bookModel.Title,
            //    Description = bookModel.Description,
            //};
            var book = _mapper.Map<Books>(bookModel);

            _context.Books.Add(book);
            await _context.SaveChangesAsync();

            return book.Id;
        }

        // PUT API
        public async Task UpdateBookAsync(int bookId, BookModel bookModel)
        {

            //    var book = await _context.Books.FindAsync(bookId);
            //    if(book != null)
            //    {
            //        book.Title = bookModel.Title;
            //        book.Description = bookModel.Description;
            // var book = _mapper.Map<Books>(bookModel);  // Automapper in this line

            //        await _context.SaveChangesAsync();
            //    }

            // PUT API update one item 

            var book = new Books()     // creating object this line
            {
                Id = bookId,
                Title = bookModel.Title,
                Description = bookModel.Description,
            };

           // var book = _mapper.Map<Books>(bookModel); // Automapper in this line

            _context.Books.Update(book);   // asing the context 
         await _context.SaveChangesAsync();     //changes the database this line 
        }

        // PATCH API

        public async Task UpdateBookPatchAsync(int bookId, JsonPatchDocument bookModel)
        {
            var book = await _context.Books.FindAsync(bookId);
            if(book != null)
            {
                bookModel.ApplyTo(book);
                await _context.SaveChangesAsync();
            }
        }

        // DELETE API 
        public async Task DeleteBooksAsync(int bookId)
        {
            var book = new Books()
            {
                Id = bookId,
            };

            _context.Books.Remove(book);

            await _context.SaveChangesAsync();

        }
    }
}
