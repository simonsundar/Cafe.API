// Program.cs
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using MongoDB.Driver;
using MediatR;
using GICCafe.Domain.Intefaces;
using GICCafe.Infrastructure.Repositories;
using System.Reflection;
using GICCafe.API.SeedData;

var builder = WebApplication.CreateBuilder(args);

// Configure services
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Add MediatR
builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));

// Add MongoDB
builder.Services.AddSingleton<IMongoClient>(sp =>
{
   // var connectionString = builder.Configuration.GetConnectionString("MongoDb");
    var connectionString = "mongodb://localhost:27017";
    return new MongoClient(connectionString);
});

builder.Services.AddScoped<IMongoDatabase>(sp =>
{
    var client = sp.GetRequiredService<IMongoClient>();
  //  var databaseName = builder.Configuration.GetValue<string>("MongoDb:Database");
    var databaseName = "GICDB";
    return client.GetDatabase(databaseName);
});

// Register repositories
builder.Services.AddScoped<ICafeRepository, CafeRepository>();
builder.Services.AddScoped<IEmployeeRepository, EmployeeRepository>();
builder.Services.AddScoped<MongoSeeder>();

var app = builder.Build();

// Seed the database with initial data
using (var scope = app.Services.CreateScope())
{
    var seeder = scope.ServiceProvider.GetRequiredService<MongoSeeder>();
    await seeder.SeedAsync();

}
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
