using CQRS_Pattern.Data.Command;
using CQRS_Pattern.Repository;
using MediatR;

namespace CQRS_Pattern.Data.Handler
{
    public class UpdateCustomerHandler : IRequestHandler<UpdateCustomerCommand, int>
    {
        private readonly ICustomerRepository _customerRepository;
        public UpdateCustomerHandler(ICustomerRepository customerRepository)
        {
            _customerRepository = customerRepository;
        }

        public async Task<int> Handle(UpdateCustomerCommand request, CancellationToken cancellation)
        {
            var cus = await _customerRepository.GetByIdCustomerAsync(request.Id);

            if (cus == null) return default;

            cus.Name = request.Name;
            cus.Address = request.Address;
            cus.Phone = request.Phone;
            cus.Email = request.Email;

            return await _customerRepository.UpdateCustomerAsync(cus);


        }
    }
}
