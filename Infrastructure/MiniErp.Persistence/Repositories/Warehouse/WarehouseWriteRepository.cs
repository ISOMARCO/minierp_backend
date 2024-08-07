using MiniErp.Application.Repositories.Warehouse;
using MiniErp.Persistence.Contexts;

namespace MiniErp.Persistence.Repositories.Warehouse;

public class WarehouseWriteRepository(MiniErpDbContext context) : WriteRepository<Domain.Entities.Warehouse>(context), IWarehouseWriteRepository
{
    
}