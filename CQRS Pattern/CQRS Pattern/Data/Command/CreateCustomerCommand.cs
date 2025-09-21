using CQRS_Pattern.Model;
using MediatR;

namespace CQRS_Pattern.Data.Command
{
    public class CreateCustomerCommand : IRequest<Customer>
    {
        public CreateCustomerCommand(string name, string address, string phone, string email)
        {
            Name = name;
            Address = address;
            Phone = phone;
            Email = email;
        }

        public string Name { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
    }
}
