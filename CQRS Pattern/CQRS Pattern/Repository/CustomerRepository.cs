using CQRS_Pattern.Data;
using CQRS_Pattern.Model;
using Microsoft.EntityFrameworkCore;

namespace CQRS_Pattern.Repository
{
    public class CustomerRepository : ICustomerRepository
    {
        private readonly CustomerContext _context;
        public CustomerRepository(CustomerContext context)
        {
            _context = context;
        }

        public async Task<List<Customer>> GetAllCustomerListAsync()
        {
            var result = await _context.Customers.ToListAsync();
            return result;
        }

        public async Task<Customer> GetByIdCustomerAsync(int id)
        {
            var result = await _context.Customers.Where(x => x.Id == id).FirstOrDefaultAsync();
            return result;
        }

        public async Task<Customer> AddCustomerAsync(Customer customer)
        {
            _context.Customers.Add(customer);
            await _context.SaveChangesAsync();
            return customer;
        }

        public async Task<int> UpdateCustomerAsync(Customer customer)
        {
            _context.Customers.Update(customer);
            return await _context.SaveChangesAsync();
        }

        public async Task<int> DeleteCustomerAsync(int Id)
        {
            var result = _context.Customers.Where(x => x.Id == Id).FirstOrDefault();
            _context.Customers.Remove(result);
            return await _context.SaveChangesAsync();
        }
    }
}
