using Microsoft.EntityFrameworkCore;
using MiniErp.Application.Features.CQRS.Results.ApiEndpointResults;
using MiniErp.Application.Repositories.ApiEndpoint;

namespace MiniErp.Application.Features.CQRS.Handlers.ApiEndpointHandlers;

public class GetApiEndpointQueryHandler(
    IApiEndpointReadRepository readRepository
    )
{
    public async Task<List<GetApiEndpointQueryResult>> Handle()
    {
        var apiEndpoints = readRepository.GetAll(false);
        return await apiEndpoints.Select(a => new GetApiEndpointQueryResult
        {
            Id = a.Id,
            Name = a.Name,
            Code = a.Code,
            Controller = a.Controller,
            Method = a.Method,
            Action = a.Action,
            QueryString = a.QueryString
        }).ToListAsync();
    }
}