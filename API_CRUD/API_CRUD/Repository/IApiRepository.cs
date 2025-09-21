using API_CRUD.Model;

namespace API_CRUD.Repository
{
    public interface IApiRepository
    {
        Task<List<ApiModel>> GetAllAsync();
        Task<ApiModel> GetByIdAsync(int id);
        Task<int> AddAsync(ApiModel model);
        Task UpdateAsync(ApiModel model, int id);
        Task<int> DeleteAsync(int id);
    }
}
