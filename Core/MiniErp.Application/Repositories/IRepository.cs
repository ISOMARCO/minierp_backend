using Microsoft.EntityFrameworkCore;
using MiniErp.Domain.Entities.Common;

namespace MiniErp.Application.Repositories;

public interface IRepository<T> where T : BaseEntity
{
    DbSet<T> Table { get; }
}