using CQRS_Pattern.Model;
using MediatR;

namespace CQRS_Pattern.Data.Query
{
    public class GetByIdCustomerQuery : IRequest<Customer>
    {
        public int Id { get; set; }
    }
}
