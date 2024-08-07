using MiniErp.Application.Repositories.Warehouse;
using MiniErp.Persistence.Contexts;

namespace MiniErp.Persistence.Repositories.Warehouse;

public class WarehouseReadRepository(MiniErpDbContext context) : ReadRepository<Domain.Entities.Warehouse>(context), IWarehouseReadRepository
{
    
}