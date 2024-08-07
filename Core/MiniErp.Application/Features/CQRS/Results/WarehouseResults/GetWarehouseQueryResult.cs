namespace MiniErp.Application.Features.CQRS.Results.WarehouseResults;

public class GetWarehouseQueryResult
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public bool IsActive { get; set; } = true;
    public bool InUse { get; set; } = false;
}