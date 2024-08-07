using MiniErp.Application.Filters.Customer;

namespace MiniErp.Application.Repositories.Customer;

public interface ICustomerReadRepository : IReadRepository<Domain.Entities.Customer>
{
    Task<IEnumerable<Domain.Entities.Customer>> GetCustomersByFilterAsync(CustomerFilter filter);
}