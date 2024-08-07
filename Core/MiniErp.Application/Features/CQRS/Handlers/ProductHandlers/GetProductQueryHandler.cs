using Microsoft.EntityFrameworkCore;
using MiniErp.Application.Features.CQRS.Results.ProductResults;
using MiniErp.Application.Repositories.Product;

namespace MiniErp.Application.Features.CQRS.Handlers.ProductHandlers;

public class GetProductQueryHandler(
    IProductReadRepository readRepository
    )
{
    public async Task<List<GetProductQueryResult>> Handle(int page, int size)
    {
        var products = readRepository.GetAll(false).Skip(page * size).Take(size);
        return await products.Select(product => new GetProductQueryResult
        {
            Id = product.Id,
            Name = product.Name,
            Type = product.Type,
            Note = product.Note
        }).ToListAsync();
    }
}