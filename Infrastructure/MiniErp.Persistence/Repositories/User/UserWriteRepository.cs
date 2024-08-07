using MiniErp.Application.Repositories.User;
using MiniErp.Persistence.Contexts;

namespace MiniErp.Persistence.Repositories.User;

public class UserWriteRepository(MiniErpDbContext context) : WriteRepository<Domain.Entities.User>(context), IUserWriteRepository
{
    
}