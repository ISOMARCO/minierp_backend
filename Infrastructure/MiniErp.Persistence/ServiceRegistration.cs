using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using MiniErp.Application.Repositories.ApiEndpoint;
using MiniErp.Application.Repositories.Customer;
using MiniErp.Application.Repositories.Product;
using MiniErp.Application.Repositories.TransactionType;
using MiniErp.Application.Repositories.TransactionTypeStatus;
using MiniErp.Application.Repositories.User;
using MiniErp.Application.Repositories.Warehouse;
using MiniErp.Persistence.Contexts;
using MiniErp.Persistence.Repositories.ApiEndpoint;
using MiniErp.Persistence.Repositories.Customer;
using MiniErp.Persistence.Repositories.Product;
using MiniErp.Persistence.Repositories.TransactionType;
using MiniErp.Persistence.Repositories.TransactionTypeStatus;
using MiniErp.Persistence.Repositories.User;
using MiniErp.Persistence.Repositories.Warehouse;

namespace MiniErp.Persistence;

public static class ServiceRegistration
{
    public static void AddPersistenceServices(this IServiceCollection services)
    {
        services.AddDbContext<MiniErpDbContext>(options =>
            options.UseNpgsql(Configuration.ConnectionString));
        services.AddScoped<IUserReadRepository, UserReadRepository>();
        services.AddScoped<IUserWriteRepository, UserWriteRepository>();
        services.AddScoped<ICustomerReadRepository, CustomerReadRepository>();
        services.AddScoped<ICustomerWriteRepository, CustomerWriteRepository>();
        services.AddScoped<IProductReadRepository, ProductReadRepository>();
        services.AddScoped<IProductWriteRepository, ProductWriteRepository>();
        services.AddScoped<ITransactionTypeReadRepository, TransactionTypeReadRepository>();
        services.AddScoped<ITransactionTypeWriteRepository, TransactionTypeWriteRepository>();
        services.AddScoped<IApiEndpointReadRepository, ApiEndpointReadRepository>();
        services.AddScoped<IApiEndpointWriteRepository, ApiEndpointWriteRepository>();
        services.AddScoped<ITransactionTypeStatusReadRepository, TransactionTypeStatusReadRepository>();
        services.AddScoped<ITransactionTypeStatusWriteRepository, TransactionTypeStatusWriteRepository>();
        services.AddScoped<IWarehouseReadRepository, WarehouseReadRepository>();
        services.AddScoped<IWarehouseWriteRepository, WarehouseWriteRepository>();
    }
}