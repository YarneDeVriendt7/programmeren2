using WebShoppie.Storage.Queries;
using WebShoppieAalst.Domain.Services.Implementations;
using WebShoppieAalst.Domain.Services.Interfaces.Repositories;
using WebShoppieAalst.Domain.Services.Interfaces.Services;
using WebShoppieAalst.Storage;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddScoped<ICustomerService, CustomerService>();
builder.Services.AddSingleton<ICustomerRepository, DapperCustomerRepository>();
builder.Services.AddScoped<IProductService, ProductService>();
builder.Services.AddSingleton<IProductRepository, DapperProductRepository>();
builder.Services.AddSingleton<ProductQueries>();
builder.Services.AddScoped<IOrderService, OrderService>();
builder.Services.AddSingleton<IOrderRepository, DapperOrderRepository>();

var app = builder.Build();

app.MapControllers();

app.Run();