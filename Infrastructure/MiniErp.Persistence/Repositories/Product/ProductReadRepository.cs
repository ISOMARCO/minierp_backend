using Microsoft.EntityFrameworkCore;
using MiniErp.Application.Filters.Product;
using MiniErp.Application.Repositories.Product;
using MiniErp.Persistence.Contexts;

namespace MiniErp.Persistence.Repositories.Product;

public class ProductReadRepository(MiniErpDbContext context) : ReadRepository<Domain.Entities.Product>(context), IProductReadRepository
{
    public async Task<IEnumerable<Domain.Entities.Product>> GetProductsByFilterAsync(ProductFilter filter)
    {
        var query = context.Products.AsQueryable();
        if (!string.IsNullOrEmpty(filter.Name))
        {
            query = query.Where(x => x.Name.ToLower().Contains(filter.Name.ToLower()));
        }
        if (!string.IsNullOrEmpty(filter.Type))
        {
            query = query.Where(x => x.Type.ToLower().Contains(filter.Type.ToLower()));
        }
        if (!string.IsNullOrEmpty(filter.Note))
        {
            query = query.Where(x => x.Note != null && x.Note.ToLower().Contains(filter.Note.ToLower()));
        }
        return await query.ToListAsync();
    }
}