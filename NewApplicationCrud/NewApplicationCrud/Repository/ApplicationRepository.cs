using NewApplicationCrud.Model;
using Microsoft.EntityFrameworkCore;
using NewApplicationCrud.Data;

namespace NewApplicationCrud.Repository
{
    public class ApplicationRepository : IApplicationRepository
    {
        private readonly ApplicationContext _context;
        public ApplicationRepository(ApplicationContext context)
        {
            _context = context;
        }

        public async Task<List<ApplicationModel>> GetAllAsync()
        {
            var result = await _context.ApplicationModels.ToListAsync();
            return result;
        }

        public async Task<ApplicationModel> GetByIdAsync(int id)
        {
            var result = await _context.ApplicationModels.Where(x => x.Id == id).FirstOrDefaultAsync();
            if (result == null)
            {
                throw new Exception("Not Found");
            }
            return result;
        }

        public async Task<int> CreateAsync(ApplicationModel model)
        {
            if (model == null)
            {
                throw new Exception("Not Found");
            }
            _context.ApplicationModels.Add(model);
            await _context.SaveChangesAsync();

            return model.Id;
        }

        public async Task<ApplicationModel> UpdateAsync(ApplicationModel model, int id)
        {
            //var result = await _context.ApplicationModels.Where(x => x.Id== id).FirstOrDefaultAsync();
            var result = await _context.ApplicationModels.FindAsync(id);
            if (result != null)
            {
                result.Name = model.Name;
                result.Description = model.Description;

                await _context.SaveChangesAsync();

                return result;
            }
            return null;
        }

        public async Task<int> DeleteAsync(int id)
        {
            var result = await _context.ApplicationModels.FindAsync(id);
            if (result == null)
            {
                throw new Exception("Not Found");
            }

            _context.ApplicationModels.Remove(result);
            await _context.SaveChangesAsync();
            return result.Id;


        }
    }
}
