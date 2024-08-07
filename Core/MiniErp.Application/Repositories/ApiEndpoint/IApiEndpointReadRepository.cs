using MiniErp.Domain.Entities;

namespace MiniErp.Application.Repositories.ApiEndpoint;

public interface IApiEndpointReadRepository : IReadRepository<ApiEndpoints>
{
    Task  <IEnumerable<ApiEndpoints>> GetApiEndpointsByCodeAsync(IEnumerable<string>? codes);
}