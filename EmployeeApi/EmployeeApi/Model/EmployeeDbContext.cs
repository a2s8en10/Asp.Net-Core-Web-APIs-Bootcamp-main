using Microsoft.EntityFrameworkCore;

namespace EmployeeApi.Model
{
    public class EmployeeDbContext : DbContext
    {
        public EmployeeDbContext(DbContextOptions<EmployeeDbContext> options) : base(options)
        {

        }
        public DbSet<EmployeeData> EmployeesData { get; set; }
    }
}
