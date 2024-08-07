using MiniErp.Application.Features.CQRS.Handlers.ApiEndpointHandlers;
using MiniErp.Application.Features.CQRS.Handlers.CustomerHandlers;
using MiniErp.Application.Features.CQRS.Handlers.ProductHandlers;
using MiniErp.Application.Features.CQRS.Handlers.TransactionTypesHandlers;
using MiniErp.Application.Features.CQRS.Handlers.TransactionTypeStatusHandlers;
using MiniErp.Application.Features.CQRS.Handlers.UserHandlers;
using MiniErp.Application.Features.CQRS.Handlers.WarehouseHandlers;
using MiniErp.Persistence;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddCors(options => options.AddDefaultPolicy(policy => 
    policy.WithOrigins("http://localhost:4200", "https://localhost:4200/", "http://192.168.1.108:4200", "http://localhost:5000").AllowAnyMethod().AllowAnyHeader()
));
builder.Services.AddPersistenceServices();

builder.Services.AddScoped<CreateUserHandler>();
builder.Services.AddScoped<UpdateUserHandler>();
builder.Services.AddScoped<GetCustomerQueryHandler>();
builder.Services.AddScoped<CreateCustomerCommandHandler>();
builder.Services.AddScoped<UpdateCustomerCommandHandler>();
builder.Services.AddScoped<GetUserWithFilterQueryHandler>();
builder.Services.AddScoped<GetCustomerWithFilterQueryHandler>();
builder.Services.AddScoped<GetProductQueryHandler>();
builder.Services.AddScoped<GetProductWithFilterQueryHandler>();
builder.Services.AddScoped<GetProductByIdQueryHandler>();
builder.Services.AddScoped<CreateProductCommandHandler>();
builder.Services.AddScoped<UpdateProductCommandHandler>();
builder.Services.AddScoped<DeleteCustomerCommandHandler>();
builder.Services.AddScoped<DeleteProductCommandHandler>();
builder.Services.AddScoped<GetTransactionTypeQueryHandler>();
builder.Services.AddScoped<CreateTransactionTypeCommandHandler>();
builder.Services.AddScoped<GetApiEndpointQueryHandler>();
builder.Services.AddScoped<GetApiEndpointByCodeQueryHandler>();
builder.Services.AddScoped<UpdateTransactionTypeCommandHandler>();
builder.Services.AddScoped<DeleteTransactionTypeCommandHandler>();
builder.Services.AddScoped<GetTransactionTypeStatusQueryHandler>();
builder.Services.AddScoped<CreateTransactionTypeStatusCommandHandler>();
builder.Services.AddScoped<UpdateTransactionTypeStatusCommandHandler>();
builder.Services.AddScoped<DeleteTransactionTypeStatusCommandHandler>();
builder.Services.AddScoped<GetWarehouseQueryHandler>();
builder.Services.AddScoped<CreateWarehouseCommandHandler>();
builder.Services.AddScoped<UpdateWarehouseCommandHandler>();
builder.Services.AddScoped<DeleteWarehouseCommandHandler>();

builder.Services.AddControllers();
var app = builder.Build();
// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}


app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();
app.UseCors();
app.MapControllers();
app.UseEndpoints(endpoints => { endpoints.MapControllers(); });
app.Run();
