using CQRS_Pattern.Data.Query;
using CQRS_Pattern.Model;
using CQRS_Pattern.Repository;
using MediatR;
using Microsoft.Identity.Client;

namespace CQRS_Pattern.Data.Handler
{
    public class GetByIdCustomerHandler : IRequestHandler<GetByIdCustomerQuery, Customer>
    {
        private readonly ICustomerRepository _customerRepository;
        public GetByIdCustomerHandler(ICustomerRepository customerRepository)
        {
            _customerRepository = customerRepository;
        }

        public async Task<Customer> Handle(GetByIdCustomerQuery request, CancellationToken cancellation)
        {
            return await _customerRepository.GetByIdCustomerAsync(request.Id);
        }
    }
}
