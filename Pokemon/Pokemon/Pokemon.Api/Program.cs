using Pokemon.Domain.Services.Implementations;
using Pokemon.Domain.Services.Interfaces.Repositories;
using Pokemon.Domain.Services.Interfaces.Services;
using Pokemon.Storage.Repos;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddScoped<IVideogameService, VideogameService>();
builder.Services.AddSingleton<IVideogameRepository, VideogameRepository>();
builder.Services.AddOpenApi();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
