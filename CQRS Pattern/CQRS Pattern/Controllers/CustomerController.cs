using CQRS_Pattern.Data.Command;
using CQRS_Pattern.Data.Query;
using CQRS_Pattern.Model;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CQRS_Pattern.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly IMediator _mediator;
        public CustomerController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<List<Customer>> CustomersList()
        {
            var CustomersList = await _mediator.Send(new GetAllCustomerListQuery());
            return CustomersList;
        }

        [HttpGet("{id}")]
        public async Task<Customer> CustomerById(int id)
        {
            var result = await _mediator.Send(new GetByIdCustomerQuery() { Id = id });
            return result;
        } 

        [HttpPost]
        public async Task<Customer> CreateCustomer(Customer customer)
        {
            var result = await _mediator.Send(new CreateCustomerCommand(
                customer.Name, customer.Address, customer.Phone, customer.Email));
            return result;
        }

        [HttpPut("{id}")]
        public async Task<int> UpdateCustomer(Customer customer)
        {
            var result = await _mediator.Send(new UpdateCustomerCommand(
                customer.Id, customer.Name, customer.Address, customer.Phone, customer.Email));
            return result;
        }

        [HttpDelete("{id}")]
        public async Task<int> DeleteCustomer(int id)
        {
            return await _mediator.Send(new DeleteCustomerCommand() { Id = id });
            
        }

    }
}
