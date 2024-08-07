using Microsoft.EntityFrameworkCore;
using MiniErp.Application.Features.CQRS.Results.CustomerResults;
using MiniErp.Application.Repositories.Customer;
using MiniErp.Application.RequestParameters;

namespace MiniErp.Application.Features.CQRS.Handlers.CustomerHandlers;

public class GetCustomerQueryHandler(
    ICustomerReadRepository repository
    )
{
    public async Task<List<GetCustomerQueryResult>> Handle(int page, int size)
    {
        var customers = repository.GetAll(false).Skip(page * size).Take(size);
        return await customers.Select(c => new GetCustomerQueryResult
        {
            Id = c.Id,
            FullName = c.FullName,
            Address = c.Address,
            PhoneNumber = c.PhoneNumber,
            TIN = c.TIN,
            Email = c.Email
        }).ToListAsync();
    }
}