using CQRS_Pattern.Model;
using Microsoft.EntityFrameworkCore;

namespace CQRS_Pattern.Data
{
    public class CustomerContext : DbContext
    {
        public CustomerContext(DbContextOptions<CustomerContext> options) : base(options) { }

        public DbSet<Customer> Customers { get; set; }
    }
}
