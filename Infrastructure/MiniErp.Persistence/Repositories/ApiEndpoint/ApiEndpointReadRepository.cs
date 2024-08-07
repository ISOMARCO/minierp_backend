using Microsoft.EntityFrameworkCore;
using MiniErp.Application.Repositories.ApiEndpoint;
using MiniErp.Domain.Entities;
using MiniErp.Persistence.Contexts;

namespace MiniErp.Persistence.Repositories.ApiEndpoint;

public class ApiEndpointReadRepository(MiniErpDbContext context) : ReadRepository<ApiEndpoints>(context), IApiEndpointReadRepository 
{
    public async Task<IEnumerable<ApiEndpoints>> GetApiEndpointsByCodeAsync(IEnumerable<string>? codes)
    {
        if (codes == null)
        {
            return await context.ApiEndpoints.ToListAsync();
        }
        return await context.ApiEndpoints.Where(x => codes.Contains(x.Code)).ToListAsync();
    }
}