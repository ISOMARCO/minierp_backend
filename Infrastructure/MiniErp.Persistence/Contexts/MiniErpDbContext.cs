using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using MiniErp.Domain.Entities;
using MiniErp.Domain.Entities.Common;
using MiniErp.Domain.Entities.Parameters;
using Newtonsoft.Json;

namespace MiniErp.Persistence.Contexts;

public class MiniErpDbContext(DbContextOptions<MiniErpDbContext> options) : DbContext(options)
{
    public DbSet<User> Users { get; set; }
    public DbSet<Customer> Customers { get; set; }
    public DbSet<Product> Products { get; set; }
    public DbSet<TransactionTypes> TransactionTypes { get; set; }
    public DbSet<ApiEndpoints> ApiEndpoints { get; set; }
    public DbSet<TransactionTypeStatuses> TransactionTypeStatuses { get; set; }
    public DbSet<Warehouse> Warehouses { get; set; }
    public DbSet<TransactionsJournal> TransactionsJournal { get; set; }
    public DbSet<Transactions> Transactions { get; set; }

    public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        var datas = ChangeTracker.Entries<BaseEntity>();
        foreach (var data in datas)
        {
            _ = data.State switch
            {
                EntityState.Added => data.Entity.CreatedDate = DateTime.UtcNow,
                EntityState.Modified => data.Entity.UpdatedDate = DateTime.UtcNow,
                _ => DateTime.UtcNow
            };
        }
        return await base.SaveChangesAsync(cancellationToken);
    }
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        var objectsConverter = new ValueConverter<Objects, string>(
                v => JsonConvert.SerializeObject(v),
                v => JsonConvert.DeserializeObject<Objects>(v)
            );

        modelBuilder.Entity<ApiEndpoints>()
            .Property(e => e.Objects)
            .HasConversion(objectsConverter);
        
        modelBuilder.Entity<ApiEndpoints>()
            .Property(e => e.Id)
            .HasDefaultValueSql("uuid_generate_v4()");
        
        modelBuilder.Entity<TransactionTypes>()
            .Property(e => e.Id)
            .HasDefaultValueSql("uuid_generate_v4()");
        
        modelBuilder.Entity<Warehouse>()
            .Property(e => e.Id)
            .HasDefaultValueSql("uuid_generate_v4()");
        
        modelBuilder.Entity<TransactionTypes>()
            .HasOne(t => t.ApiEndpointSource)
            .WithMany()
            .HasForeignKey(t => t.SourceParameter)
            .OnDelete(DeleteBehavior.Restrict);

        modelBuilder.Entity<TransactionTypes>()
            .HasOne(t => t.ApiEndpointDestination)
            .WithMany()
            .HasForeignKey(t => t.DestinationParameter)
            .OnDelete(DeleteBehavior.Restrict);
        
        modelBuilder.Entity<TransactionTypes>()
            .HasOne(t => t.TransactionTypeStatusesSource)
            .WithMany()
            .HasForeignKey(t => t.SourceToDestinationStatus)
            .OnDelete(DeleteBehavior.Restrict);
        
        modelBuilder.Entity<TransactionTypes>()
            .HasOne(t => t.TransactionTypeStatusesDestination)
            .WithMany()
            .HasForeignKey(t => t.DestinationToSourceStatus)
            .OnDelete(DeleteBehavior.Restrict);

        modelBuilder.Entity<TransactionsJournal>()
            .HasOne(t => t.TransactionTypes)
            .WithMany()
            .HasForeignKey(t => t.Id);

        modelBuilder.Entity<Transactions>()
            .HasOne(t => t.TransactionTypes)
            .WithMany()
            .HasForeignKey(t => t.Id);
        
        modelBuilder.Entity<ApiEndpoints>()
            .HasIndex(p => p.Code)
            .IsUnique();
    }
}