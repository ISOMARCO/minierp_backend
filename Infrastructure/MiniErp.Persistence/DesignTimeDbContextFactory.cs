using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using MiniErp.Persistence.Contexts;

namespace MiniErp.Persistence;

public class DesignTimeDbContextFactory : IDesignTimeDbContextFactory<MiniErpDbContext>
{
    public MiniErpDbContext CreateDbContext(string[] args)
    {
        var optionsBuilder = new DbContextOptionsBuilder<MiniErpDbContext>();
        optionsBuilder.UseNpgsql(Configuration.ConnectionString);
        return new MiniErpDbContext(optionsBuilder.Options);
    }
}