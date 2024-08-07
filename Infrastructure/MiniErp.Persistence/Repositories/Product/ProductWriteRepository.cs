using MiniErp.Application.Repositories.Product;
using MiniErp.Persistence.Contexts;

namespace MiniErp.Persistence.Repositories.Product;

public class ProductWriteRepository(MiniErpDbContext context) : WriteRepository<Domain.Entities.Product>(context), IProductWriteRepository;