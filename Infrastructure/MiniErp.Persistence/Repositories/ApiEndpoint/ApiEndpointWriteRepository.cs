using MiniErp.Application.Repositories.ApiEndpoint;
using MiniErp.Domain.Entities;
using MiniErp.Persistence.Contexts;

namespace MiniErp.Persistence.Repositories.ApiEndpoint;

public class ApiEndpointWriteRepository(MiniErpDbContext context) : WriteRepository<ApiEndpoints>(context), IApiEndpointWriteRepository
{
    
}