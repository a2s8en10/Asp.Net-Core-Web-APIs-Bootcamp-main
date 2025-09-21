using Microsoft.EntityFrameworkCore;
using practice_Crud_in_EF.Model;

namespace practice_Crud_in_EF.Data
{
    public class StudentContext : DbContext
    {
        public StudentContext(DbContextOptions<StudentContext> option) : base(option) { }
        public DbSet<StudentModel> Students { get; set; }
    }
}
