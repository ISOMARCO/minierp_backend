using MiniErp.Application.Features.CQRS.Queries.ProductQueries;
using MiniErp.Application.Features.CQRS.Results.ProductResults;
using MiniErp.Application.Repositories.Product;

namespace MiniErp.Application.Features.CQRS.Handlers.ProductHandlers;

public class GetProductByIdQueryHandler(IProductReadRepository readRepository)
{
    public async Task<GetProductByIdQueryResult> Handle(GetProductByIdQuery query)
    {
        var product = await readRepository.GetByIdAsync(query.Id);
        return new GetProductByIdQueryResult
        {
            Id = product.Id,
            Name = product.Name,
            Type = product.Type,
            Note = product.Note
        };
    }
}