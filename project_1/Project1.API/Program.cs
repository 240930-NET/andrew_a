using Microsoft.EntityFrameworkCore;
using Project1.API.Data;
using Project1.API.Repository;
using Project1.API.Service;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
// Add DB context and service dependencies
builder.Services.AddDbContext<Project1Context>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("Project1")));
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<ICreatureService, CreatureService>();
builder.Services.AddScoped<ICreatureRepository, CreatureRepository>();
builder.Services.AddControllers();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.MapControllers();
app.Run();