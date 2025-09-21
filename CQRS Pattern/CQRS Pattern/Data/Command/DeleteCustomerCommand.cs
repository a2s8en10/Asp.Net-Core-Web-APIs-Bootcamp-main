using MediatR;

namespace CQRS_Pattern.Data.Command
{
    public class DeleteCustomerCommand : IRequest<int>
    {
        public int Id { get; set; }
    }
}
