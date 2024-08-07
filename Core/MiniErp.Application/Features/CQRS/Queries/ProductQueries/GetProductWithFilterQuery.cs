using MiniErp.Application.Filters.Product;

namespace MiniErp.Application.Features.CQRS.Queries.ProductQueries;

public class GetProductWithFilterQuery
{
    public ProductFilter? Filter { get; set; }
}