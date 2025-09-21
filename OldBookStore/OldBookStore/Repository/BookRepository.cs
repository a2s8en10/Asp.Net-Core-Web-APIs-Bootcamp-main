using AutoMapper;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OldBookStore.Data;
using OldBookStore.Model;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace OldBookStore.Repository
{
    public class BookRepository : IBookRepository 
    {
        private readonly BookStoreContext _Context;

        public readonly IMapper _Mapper;

        public BookRepository(BookStoreContext context , IMapper mapper)
        {
            _Context = context;
            _Mapper = mapper;
        }
        public async Task<List<BookModel>> GetAllBooksAsync()
        {
            //var record = await _Context.Books.Select(x => new BookModel()
            //{
            //    Id = x.Id,
            //    Title = x.Title,
            //    Description = x.Description
            //}).ToListAsync();

            //return record;

            // Automapper Using
            var book = await _Context.Books.ToListAsync();
            return _Mapper.Map<List<BookModel>>(book);

        }

        public async Task<BookModel> GetBookByIdAsync(int BookId)
        {
            //var record = await _Context.Books.Where(x => x.Id == BookId).Select(x => new BookModel()
            //{
            //    Id = x.Id,
            //    Title = x.Title,
            //    Description = x.Description

            //}).FirstOrDefaultAsync();

            //return record;

            var book = await _Context.Books.FindAsync(BookId);
            return _Mapper.Map<BookModel>(book);
        }

        public async Task<int> AddBookAsync(BookModel bookModel)
        {
            //var book = new Books()
            //{
            //    Title = bookModel.Title,
            //    Description = bookModel.Description
            //};
            //_Context.Books.Add(book);
            //await _Context.SaveChangesAsync();

            //return book.Id;

            var book = _Mapper.Map<Books>(bookModel);
            _Context.Books.Add(book);
            await _Context.SaveChangesAsync();

            return book.Id;


        }

        public async Task UpdateBookAsync(BookModel bookModel, int id)
        {
            //var book = await _Context.Books.FindAsync(id);
            //if (book != null)
            //{
            //    book.Title = bookModel.Title;
            //    book.Description = bookModel.Description;

            //    await _Context.SaveChangesAsync();
            //}

            //  Update item in one database call
            var book = new Books()
            {
                Id = id,
                Title = bookModel.Title,
                Description = bookModel.Description
            };

            _Context.Books.Update(book);
            await _Context.SaveChangesAsync();

            //var book = _Mapper.Map(bookModel, id);
            //_Context.Books.Update(book);
            //await _Context.SaveChangesAsync();

        }

        public async Task UpdateBookPatchAsync(JsonPatchDocument bookModel, int id)
        {
            var book = await _Context.Books.FindAsync(id);

            if (book != null)
            {
                bookModel.ApplyTo(book);
                await _Context.SaveChangesAsync();
            }
        }

        public async Task DeleteBookAsync(int id)
        {
            var book = new Books() { Id = id };

            _Context.Books.Remove(book);

           await _Context.SaveChangesAsync();
        }
    }
}
