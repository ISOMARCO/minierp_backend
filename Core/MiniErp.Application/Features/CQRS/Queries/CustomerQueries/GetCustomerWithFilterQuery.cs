using MiniErp.Application.Filters.Customer;

namespace MiniErp.Application.Features.CQRS.Queries.CustomerQueries;

public class GetCustomerWithFilterQuery
{
    public CustomerFilter? Filter { get; set; }
}