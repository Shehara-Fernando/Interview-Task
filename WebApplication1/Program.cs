using Microsoft.Data.SqlClient;
using TaskManagement.Domain.Interfaces;
using Taskmanagement.Application.Handlers.Interfaces;
using Taskmanagement.Application.Handlers.Services;
using Task_Management.Infrastructure.HttpServices;
using TaskManagement.Infrastructure.Data.Repositories.Read;
using TaskManagement.Infrastructure.Data;
using TaskManagement.Domain.Constants;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var connectionString = builder.Configuration.GetConnectionString(AppConstants.ConnectionStrings.DefaultConnection);
builder.Services.AddSingleton(new SqlConnectionFactory(connectionString));
builder.Services.AddScoped<IPokemonRepository, PokemonRepository>();
builder.Services.AddHttpClient<IPokeApiService, PokeApiService>();
builder.Services.AddScoped<PokemonService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();

