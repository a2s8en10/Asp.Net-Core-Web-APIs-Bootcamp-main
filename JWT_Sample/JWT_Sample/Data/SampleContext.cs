using JWT_Sample.Model;
using Microsoft.EntityFrameworkCore;

namespace JWT_Sample.Data
{
    public class SampleContext : DbContext
    {
        public SampleContext(DbContextOptions<SampleContext> options): base (options) { }

        DbSet<Sample> samples { get; set; }
    }
}
