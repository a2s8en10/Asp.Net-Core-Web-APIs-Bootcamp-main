using Microsoft.AspNetCore.JsonPatch;
using OldBookStore.Model;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace OldBookStore.Repository
{
    public interface IBookRepository
    {
        Task<List<BookModel>> GetAllBooksAsync();
        Task<BookModel> GetBookByIdAsync(int BookId);
        Task<int> AddBookAsync(BookModel bookModel);
        Task UpdateBookAsync(BookModel bookModel, int id);
        Task UpdateBookPatchAsync(JsonPatchDocument bookModel, int id);
        Task DeleteBookAsync(int id);
    }
}
