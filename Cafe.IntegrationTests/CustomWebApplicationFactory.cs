 

namespace GICCafe.IntegrationTests
{
    using Microsoft.AspNetCore.Hosting;
    using Microsoft.AspNetCore.Mvc.Testing;
    using Microsoft.Extensions.DependencyInjection; 
    using System.Linq;
     
    using GICCafe.IntegrationTests.Seeding;
    using MongoDB.Driver;

    public class CustomWebApplicationFactory<TProgram> : WebApplicationFactory<TProgram> where TProgram : class
    {
        protected override void ConfigureWebHost(IWebHostBuilder builder)
        {
            builder.ConfigureServices(services =>
            {
                // Remove the app's DbContext registration.
                var descriptor = services.SingleOrDefault(
                    d => d.ServiceType == typeof(IMongoDatabase));

                if (descriptor != null)
                {
                    services.Remove(descriptor);
                }

                // Add a database context (IMongoDatabase) using an in-memory database for testing.
                services.AddSingleton<IMongoDatabase>(sp =>
                {
                    var mongoClient = new MongoClient("mongodb://localhost:27017");
                    return mongoClient.GetDatabase("TestDatabase");
                });

                // Build the service provider.
                var sp = services.BuildServiceProvider();

                // Create a scope to obtain a reference to the database contexts
                using var scope = sp.CreateScope();
                var scopedServices = scope.ServiceProvider;

                var db = scopedServices.GetRequiredService<IMongoDatabase>();

                // Seed the database with test data.
                SeedData.Initialize(db);
            });
        }
    }


}
