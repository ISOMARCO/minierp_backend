using Microsoft.EntityFrameworkCore;
using MiniErp.Application.Features.CQRS.Results.WarehouseResults;
using MiniErp.Application.Repositories.Warehouse;

namespace MiniErp.Application.Features.CQRS.Handlers.WarehouseHandlers;

public class GetWarehouseQueryHandler(IWarehouseReadRepository readRepository)
{
    public async Task<List<GetWarehouseQueryResult>> Handle(int page, int size)
    {
        var warehouses = readRepository.GetAll(false).Skip(page * size).Take(size);
        return await warehouses.Select(w => new GetWarehouseQueryResult
        {
            Id = w.Id,
            Name = w.Name,
            IsActive = w.IsActive,
            InUse = w.InUse
        }).ToListAsync();
    }
}