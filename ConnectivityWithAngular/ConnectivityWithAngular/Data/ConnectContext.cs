using Microsoft.EntityFrameworkCore;

namespace ConnectivityWithAngular.Data
{
    public class ConnectContext : DbContext
    {
        public ConnectContext(DbContextOptions<ConnectContext> options) : base(options) { }
        public DbSet<Model.ConnectModel> Connects { get; set; }
    }
}
