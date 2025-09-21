using CQRS_Pattern.Data.Query;
using CQRS_Pattern.Model;
using CQRS_Pattern.Repository;
using MediatR;
using Microsoft.IdentityModel.Tokens;

namespace CQRS_Pattern.Data.Handler
{
    public class GetAllCustomerListHandler : IRequestHandler<GetAllCustomerListQuery, List<Customer>>
    {
        private readonly ICustomerRepository _customerRepository;

        public GetAllCustomerListHandler(ICustomerRepository customerRepository)
        {
            _customerRepository = customerRepository;
        }

        public async Task<List<Customer>> Handle(GetAllCustomerListQuery request , CancellationToken cancellation)
        {
            return await _customerRepository.GetAllCustomerListAsync();
        }
    }
}
