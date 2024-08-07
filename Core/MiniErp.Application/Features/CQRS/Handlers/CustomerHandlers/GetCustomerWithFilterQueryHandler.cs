using MiniErp.Application.Features.CQRS.Results.CustomerResults;
using MiniErp.Application.Filters.Customer;
using MiniErp.Application.Repositories.Customer;

namespace MiniErp.Application.Features.CQRS.Handlers.CustomerHandlers;

public class GetCustomerWithFilterQueryHandler(
    ICustomerReadRepository readRepository)
{
    public async Task<List<GetCustomerWithFilterQueryResult>> Handle(CustomerFilter filter)
    {
        var customers = await readRepository.GetCustomersByFilterAsync(filter);
        return customers.Select(customer => new GetCustomerWithFilterQueryResult
        {
            Id = customer.Id,
            FullName = customer.FullName,
            Email = customer.Email,
            PhoneNumber = customer.PhoneNumber,
            Address = customer.Address,
            TIN = customer.TIN
        }).ToList();
    }
}