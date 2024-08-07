namespace MiniErp.Application.Features.CQRS.Queries.ProductQueries;

public class GetProductByIdQuery
{
    public GetProductByIdQuery(string id)
    {
        Id = id;
    }

    public string Id { get; set; }
}