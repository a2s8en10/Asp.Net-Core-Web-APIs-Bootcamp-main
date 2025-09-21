using Microsoft.EntityFrameworkCore;
using NewCRUD.Model;

namespace NewCRUD.Data
{
    public class PlayerContext : DbContext
    {
        public PlayerContext(DbContextOptions<PlayerContext> options ) : base (options) { }

        public DbSet<PlayerModel> DataPlayers { get; set; }
    }
}
