using NewCRUD.Model;

namespace NewCRUD.Repository
{
    public interface IPlayerRepository
    {
        Task<List<PlayerModel>> GetAllPlayerAsync();
        Task<PlayerModel> GetByIdPlayerAsync(int id);
        Task<PlayerModel> AddNewPlayerAsync(PlayerModel player);
        Task<PlayerModel> DeletePlayerAsync(int id);
        Task<PlayerModel> UpdatePlayerAsync(PlayerModel player, int id);
    }
}
