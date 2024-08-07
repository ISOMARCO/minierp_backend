using Microsoft.EntityFrameworkCore;
using MiniErp.Application.Filters.User;
using MiniErp.Application.Repositories.User;
using MiniErp.Persistence.Contexts;

namespace MiniErp.Persistence.Repositories.User;

public class UserReadRepository(MiniErpDbContext context) : ReadRepository<Domain.Entities.User>(context), IUserReadRepository
{
    public async Task<IEnumerable<Domain.Entities.User>> GetUsersByFilterAsync(UserFilter filter)
    {
        var query = context.Users.AsQueryable();
        if (!string.IsNullOrEmpty(filter.FirstName))
        {
            query = query.Where(x => x.FirstName.ToLower().Contains(filter.FirstName.ToLower()));
        }
        if (!string.IsNullOrEmpty(filter.LastName))
        {
            query = query.Where(x => x.LastName != null && x.LastName.ToLower().Contains(filter.LastName.ToLower()));
        }
        if (!string.IsNullOrEmpty(filter.Username))
        {
            query = query.Where(x => x.Username.ToLower().Contains(filter.Username.ToLower()));
        }
        if (!string.IsNullOrEmpty(filter.Email))
        {
            query = query.Where(x => x.Email.ToLower().Contains(filter.Email.ToLower()));
        }
        if (!string.IsNullOrEmpty(filter.PhoneNumber))
        {
            query = query.Where(x => x.PhoneNumber != null && x.PhoneNumber.ToLower().Contains(filter.PhoneNumber.ToLower()));
        }
        return await query.ToListAsync();
    }
}