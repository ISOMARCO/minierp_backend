using MiniErp.Application.Filters.Product;

namespace MiniErp.Application.Repositories.Product;

public interface IProductReadRepository : IReadRepository<Domain.Entities.Product>
{
    Task <IEnumerable<Domain.Entities.Product>> GetProductsByFilterAsync(ProductFilter filter);
}