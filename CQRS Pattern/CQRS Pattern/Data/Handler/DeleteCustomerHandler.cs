using CQRS_Pattern.Data.Command;
using CQRS_Pattern.Repository;
using MediatR;

namespace CQRS_Pattern.Data.Handler
{
    public class DeleteCustomerHandler : IRequestHandler<DeleteCustomerCommand, int>
    {
        private readonly ICustomerRepository _customerRepository;
        public DeleteCustomerHandler(ICustomerRepository customerRepository)
        {
            _customerRepository = customerRepository;
        }

        public async Task<int> Handle(DeleteCustomerCommand request , CancellationToken cancellation)
        {
            var cus = await _customerRepository.GetByIdCustomerAsync(request.Id);
            if(cus ==null) return default;
            return await _customerRepository.DeleteCustomerAsync(request.Id);
        }
    }
}
