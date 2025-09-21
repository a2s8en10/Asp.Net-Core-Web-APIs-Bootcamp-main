using API_CRUD.Model;
using Microsoft.EntityFrameworkCore;

namespace API_CRUD.Data
{
    public class ApiContext : DbContext
    {
        public ApiContext(DbContextOptions<ApiContext> options) : base(options) { }

        public DbSet<ApiModel> ApiModels { get; set; }
    }
}
