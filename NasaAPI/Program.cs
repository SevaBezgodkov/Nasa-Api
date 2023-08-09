using Microsoft.EntityFrameworkCore;
using NasaAPI.DataAccess;
using NasaAPI.Repositories;
using NasaAPI.Repositories.Interfaces;
using NasaAPI.Services;
using NasaAPI.Services.Interfaces;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddDbContext<ApplicationContext>(options =>
   options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddSingleton<HttpClient>();
builder.Services.AddTransient<IAsteroidService, AsteroidsService>();
builder.Services.AddTransient<IAsteroidRepository, AsteroidRepository>();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

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
