using Microsoft.EntityFrameworkCore;
using NewCRUD.Data;
using NewCRUD.Model;

namespace NewCRUD.Repository
{
    public class PlayerRepository : IPlayerRepository
    {
        private readonly PlayerContext _context;
        public PlayerRepository(PlayerContext context)
        {
            _context = context;
        }

        public async Task<List<PlayerModel>> GetAllPlayerAsync()
        {
            var result = await _context.DataPlayers.ToListAsync();
            return result;
        }

        public async Task<PlayerModel> GetByIdPlayerAsync(int id)
        {
            var result = await _context.DataPlayers.Where(x => x.Id == id).FirstOrDefaultAsync();
            return result;
        }

        public async Task<PlayerModel> AddNewPlayerAsync(PlayerModel player)
        {
            _context.DataPlayers.Add(player);
            await _context.SaveChangesAsync();
            return player; 
        }

        public async Task<PlayerModel> DeletePlayerAsync(int id)
        {
            var player = await _context.DataPlayers.FindAsync(id);
            _context.DataPlayers.Remove(player);
            await _context.SaveChangesAsync();
            return player;
        }

        public async Task<PlayerModel> UpdatePlayerAsync(PlayerModel player, int id)
        {
            var play = new PlayerModel()
            {
                Id = id,
                Name = player.Name,
                Email = player.Email,
                Phone = player.Phone,
            };
           
            _context.DataPlayers.Update(play);
            await _context.SaveChangesAsync();
            return player;
        }
    }
}
