using CQRS_Pattern.Data.Command;
using CQRS_Pattern.Model;
using CQRS_Pattern.Repository;
using MediatR;

namespace CQRS_Pattern.Data.Handler
{
    public class CreateCustomerHandler : IRequestHandler<CreateCustomerCommand, Customer>
    {
        private readonly ICustomerRepository _customerRepository;
        public CreateCustomerHandler(ICustomerRepository customerRepository)
        {
            _customerRepository = customerRepository;
        }
        public async Task<Customer> Handle(CreateCustomerCommand command, CancellationToken cancellation)
        {
            var cus = new Customer
            {
                Name = command.Name,
                Address = command.Address,
                Phone = command.Phone,
                Email = command.Email
            };

            return await _customerRepository.AddCustomerAsync(cus);
        }
    }
}
