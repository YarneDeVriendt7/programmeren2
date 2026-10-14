using WebShoppieAalst.Domain.Services.Implementations;
using WebShoppieAalst.Domain.Services.Interfaces;
using WebShoppieAalst.Domain.Services.Interfaces.Repositories;
using WebShoppieAalst.Domain.Services.Interfaces.Services;
using WebShoppieAalst.Storage;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddScoped<ICustomerService, CustomerService>();
builder.Services.AddSingleton<ICustomerRepository, CustomerRepository>();

var app = builder.Build();

app.MapControllers();

app.Run();