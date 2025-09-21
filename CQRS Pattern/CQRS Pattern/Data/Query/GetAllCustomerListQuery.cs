using CQRS_Pattern.Model;
using MediatR;

namespace CQRS_Pattern.Data.Query
{
    public class GetAllCustomerListQuery : IRequest<List<Customer>>
    {
    }
}
