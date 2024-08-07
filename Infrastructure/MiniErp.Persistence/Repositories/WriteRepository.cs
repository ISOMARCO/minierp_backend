using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using MiniErp.Application.Repositories;
using MiniErp.Domain.Entities.Common;
using MiniErp.Persistence.Contexts;

namespace MiniErp.Persistence.Repositories;

public class WriteRepository<T>(MiniErpDbContext context) : IWriteRepository<T> where T : BaseEntity
{
    public DbSet<T> Table => context.Set<T>();
    public async Task<bool> AddAsync(T model)
    {
        EntityEntry entityEntry = await Table.AddAsync(model);
        return entityEntry.State == EntityState.Added;
    }

    public async Task<bool> AddRangeAsync(List<T> datas)
    {
        await Table.AddRangeAsync(datas);
        return true;
    }

    public bool Remove(T model)
    {
        EntityEntry entityEntry = Table.Remove(model);
        return entityEntry.State == EntityState.Deleted;
    }

    public async Task<bool> RemoveAsync(string id)
    {
        T model = await Table.FirstOrDefaultAsync(data => data.Id == Guid.Parse(id));
        return Remove(model);
    }

    public bool RemoveRange(List<T> datas)
    {
        Table.RemoveRange(datas);
        return true;
    }

    public bool Update(T model)
    {
        EntityEntry entityEntry = Table.Update(model);
        return entityEntry.State == EntityState.Modified;
    }

    public async Task<int> SaveAsync() => await context.SaveChangesAsync();
}