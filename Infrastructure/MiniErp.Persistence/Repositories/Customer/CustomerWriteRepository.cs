using MiniErp.Application.Repositories.Customer;
using MiniErp.Persistence.Contexts;

namespace MiniErp.Persistence.Repositories.Customer;

public class CustomerWriteRepository(MiniErpDbContext context) : WriteRepository<Domain.Entities.Customer>(context), ICustomerWriteRepository
{
    
}