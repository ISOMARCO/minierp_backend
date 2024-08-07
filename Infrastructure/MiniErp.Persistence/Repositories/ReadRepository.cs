using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using MiniErp.Application.Repositories;
using MiniErp.Domain.Entities.Common;
using MiniErp.Persistence.Contexts;

namespace MiniErp.Persistence.Repositories;

public class ReadRepository<T>(MiniErpDbContext context) : IReadRepository<T> where T: BaseEntity
{
    public DbSet<T> Table => context.Set<T>();
    public IQueryable<T> GetAll(bool tracking = true)
    {
        var query = Table.AsQueryable();
        if (!tracking)
        {
            query = query.AsNoTracking();
        }
        return query;
    }

    public IQueryable<T> GetWhere(Expression<Func<T, bool>> method, bool tracking = true)
    {
        var query = Table.Where(method);
        if (!tracking)
        {
            query = query.AsNoTracking();
        }
        return query;
    }

    public async Task<T> GetSingleAsync(Expression<Func<T, bool>> method, bool tracking = true)
    {
        var query = Table.AsQueryable();
        if (!tracking)
        {
            query = Table.AsNoTracking();
        }
        return await query.FirstOrDefaultAsync(method);
    }

    public Task<T> GetByIdAsync(string id, bool tracking = true)
    {
        var query = Table.AsQueryable();
        if (!tracking)
        {
            query = Table.AsNoTracking();
        }
        return query.FirstOrDefaultAsync(data => data.Id == Guid.Parse(id));
    }
}