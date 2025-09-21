using API_CRUD.Data;
using API_CRUD.Model;
using Microsoft.EntityFrameworkCore;

namespace API_CRUD.Repository
{
    public class ApiRepository : IApiRepository
    {
        private readonly ApiContext _context;
        public ApiRepository(ApiContext context)
        {
            _context = context;
        }

        public async Task<List<ApiModel>> GetAllAsync()
        {
            var result = await _context.ApiModels.ToListAsync();
            return result;
        }

        public async Task<ApiModel> GetByIdAsync(int id)
        {
            var result = await _context.ApiModels.Where(x => x.Id == id).FirstOrDefaultAsync();
            return result;
        }

        public async Task<int> AddAsync(ApiModel model)
        {
            await _context.ApiModels.AddAsync(model);
            await _context.SaveChangesAsync();
            return model.Id;
        }

        public async Task UpdateAsync(ApiModel model, int id)
        {
            var result = await _context.ApiModels.FindAsync(id);
            if (result == null)
            {
                throw new Exception("Not Found");
            }
            result.Name = model.Name;
            result.Email = model.Email;
            result.Password = model.Password;

            await _context.SaveChangesAsync();

        }
        public async Task<int> DeleteAsync(int id)
        {
            var result = await _context.ApiModels.FindAsync(id);
            if (result == null) return 0;
            _context.ApiModels.Remove(result);
            await _context.SaveChangesAsync();
            return result.Id;

        }
    }
}
