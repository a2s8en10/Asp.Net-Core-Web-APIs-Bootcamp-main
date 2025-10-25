using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.EntityFrameworkCore;
using NewApplicationCrud.Model;

namespace NewApplicationCrud.Data
{
    public class ApplicationContext : DbContext
    {
        public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options) { }

        public DbSet<ApplicationModel> ApplicationModels  { get; set; }
    }
}
