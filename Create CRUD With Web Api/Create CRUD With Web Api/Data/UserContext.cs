using Create_CRUD_With_Web_Api.Model;
using Microsoft.EntityFrameworkCore;
namespace Create_CRUD_With_Web_Api.Data
{
    public class UserContext : DbContext
    {
        public UserContext(DbContextOptions<UserContext> options) : base(options) { }
        public DbSet<User1> User1 { get; set; }
    }
}
