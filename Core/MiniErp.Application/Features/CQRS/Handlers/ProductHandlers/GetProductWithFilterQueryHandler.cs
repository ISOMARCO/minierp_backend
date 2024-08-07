using MiniErp.Application.Features.CQRS.Results.ProductResults;
using MiniErp.Application.Filters.Product;
using MiniErp.Application.Repositories.Product;

namespace MiniErp.Application.Features.CQRS.Handlers.ProductHandlers;

public class GetProductWithFilterQueryHandler(
    IProductReadRepository readRepository
    )
{
    public async Task<List<GetProductWithFilterQueryResult>> Handle(ProductFilter filter)
    {
        var products = await readRepository.GetProductsByFilterAsync(filter);
        return products.Select(product => new GetProductWithFilterQueryResult
        {
            Id = product.Id,
            Name = product.Name,
            Type = product.Type,
            Note = product.Note
        }).ToList();
    }
}