using MiniErp.Application.Features.CQRS.Results.ApiEndpointResults;
using MiniErp.Application.Repositories.ApiEndpoint;

namespace MiniErp.Application.Features.CQRS.Handlers.ApiEndpointHandlers;

public class GetApiEndpointByCodeQueryHandler( 
    IApiEndpointReadRepository readRepository
    )
{
    public async Task<List<GetApiEndpointByCodeQueryResult>> Handle(IEnumerable<string> codes)
    {
        var apiEndpoints = await readRepository.GetApiEndpointsByCodeAsync(codes);
        return apiEndpoints.Select(a => new GetApiEndpointByCodeQueryResult
        {
            Id = a.Id,
            Name = a.Name,
            Code = a.Code,
            Controller = a.Controller,
            Method = a.Method,
            Action = a.Action,
            QueryString = a.QueryString
        }).ToList();
    }
}