namespace MiniErp.Application.Features.CQRS.Results.ProductResults;

public class GetProductByIdQueryResult
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string? Type { get; set; }
    public string? Note { get; set; }
}