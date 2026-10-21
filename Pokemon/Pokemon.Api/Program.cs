using PokemonApp.Domain.Services.Implementations;
using PokemonApp.Domain.Services.Interfaces.Repositories;
using PokemonApp.Domain.Services.Interfaces.Services;
using PokemonApp.Storage.Repos;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddScoped<IVideogameService, VideogameService>();
builder.Services.AddSingleton<IVideogameRepository, VideogameRepository>();
builder.Services.AddOpenApi();

var app = builder.Build();

builder.Services.AddControllers().AddJsonOptions(opt => {
    opt.JsonSerializerOptions.Converters.Add(
        new JsonStringEnumConverter());
});

if (app.Environment.IsDevelopment())
    app.MapOpenApi();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
