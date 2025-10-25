using NewApplicationCrud.Model;

namespace NewApplicationCrud.Repository
{
    public interface IApplicationRepository
    {
        Task<List<ApplicationModel>> GetAllAsync();
        Task<ApplicationModel> GetByIdAsync(int id);
        Task<int> CreateAsync(ApplicationModel model);
        Task<ApplicationModel> UpdateAsync(ApplicationModel model, int id);
        Task<int> DeleteAsync(int id);
    }
}
