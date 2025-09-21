using CQRS_Ex_1.Model;
using Microsoft.EntityFrameworkCore;

namespace CQRS_Ex_1.Data
{
    public class StudentContext : DbContext
    {
        public StudentContext(DbContextOptions<StudentContext> options) : base (options){ }

        public DbSet<StudentModel> studentModels { get; set; }
    }
}
