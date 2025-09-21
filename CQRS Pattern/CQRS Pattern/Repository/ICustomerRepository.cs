using CQRS_Pattern.Model;

namespace CQRS_Pattern.Repository
{
    public interface ICustomerRepository
    {
        Task<List<Customer>> GetAllCustomerListAsync();
        Task<Customer> GetByIdCustomerAsync(int id);
        Task<Customer> AddCustomerAsync(Customer customer);
        Task<int> UpdateCustomerAsync(Customer customer);
        Task<int> DeleteCustomerAsync(int Id);
    }
}
