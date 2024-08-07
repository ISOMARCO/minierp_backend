using Microsoft.EntityFrameworkCore;
using MiniErp.Application.Filters.Customer;
using MiniErp.Application.Repositories.Customer;
using MiniErp.Persistence.Contexts;

namespace MiniErp.Persistence.Repositories.Customer;

public class CustomerReadRepository(MiniErpDbContext context) : ReadRepository<Domain.Entities.Customer>(context), ICustomerReadRepository
{
    public async Task<IEnumerable<Domain.Entities.Customer>> GetCustomersByFilterAsync(CustomerFilter filter)
    {
        var query = context.Customers.AsQueryable();
        if (!string.IsNullOrEmpty(filter.FullName))
        {
            query = query.Where(x => x.FullName.ToLower().Contains(filter.FullName.ToLower()));
        }
        if (!string.IsNullOrEmpty(filter.Email))
        {
            query = query.Where(x => x.Email != null && x.Email.ToLower().Contains(filter.Email.ToLower()));
        }
        if (!string.IsNullOrEmpty(filter.PhoneNumber))
        {
            query = query.Where(x => x.PhoneNumber != null && x.PhoneNumber.Contains(filter.PhoneNumber));
        }
        if (!string.IsNullOrEmpty(filter.TIN))
        {
            query = query.Where(x => x.TIN != null && x.TIN.ToLower().Contains(filter.TIN.ToLower()));
        }
        if (!string.IsNullOrEmpty(filter.Address))
        {
            query = query.Where(x => x.Address != null && x.Address.ToLower().Contains(filter.Address.ToLower()));
        }
        return await query.ToListAsync();
    }
}