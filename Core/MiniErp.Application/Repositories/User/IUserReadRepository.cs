using MiniErp.Application.Filters.User;

namespace MiniErp.Application.Repositories.User;

public interface IUserReadRepository : IReadRepository<Domain.Entities.User>
{
    Task<IEnumerable<Domain.Entities.User>> GetUsersByFilterAsync(UserFilter filter);
}