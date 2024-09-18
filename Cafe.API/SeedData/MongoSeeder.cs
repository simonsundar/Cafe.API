using GICCafe.Domain.Entities;
using MongoDB.Driver;

namespace GICCafe.API.SeedData
{
    // Infrastructure/SeedData/MongoSeeder.cs
    public class MongoSeeder
    {
        private readonly IMongoDatabase _database;

        public MongoSeeder(IMongoDatabase database)
        {
            _database = database;
        }

        public async Task SeedAsync()
        {
            var cafes = _database.GetCollection<Cafe>("cafes");
            var employees = _database.GetCollection<Employee>("employees");

            // Seed Cafes
            var cafe1 = new Cafe
            {
                Id = "cafe1",
                Name = "Cafe Mocha",
                Description = "A cozy place to enjoy coffee",
                Location = "Downtown",
                Logo = "logo.png"
            };

            var cafe2 = new Cafe
            {
                Id = "cafe2",
                Name = "Cafe Latte",
                Description = "A chill place to relax",
                Location = "Uptown",
                Logo = "logo2.png"
            };

            await cafes.InsertManyAsync(new[] { cafe1, cafe2 });

            // Seed Employees
            var employee1 = new Employee
            {
                Id = "UI1234567",
                Name = "John Doe",
                EmailAddress = "john.doe@example.com",
                PhoneNumber = "91234567",
                Gender = "Male",
                StartDate = DateTime.Now.AddDays(-10),
                Cafe = cafe1
            };

            var employee2 = new Employee
            {
                Id = "UI1234568",
                Name = "Jane Doe",
                EmailAddress = "jane.doe@example.com",
                PhoneNumber = "91234568",
                Gender = "Female",
                StartDate = DateTime.Now.AddDays(-5),
                Cafe = cafe1
            };

            var employee3 = new Employee
            {
                Id = "UI1234569",
                Name = "Mark Smith",
                EmailAddress = "mark.smith@example.com",
                PhoneNumber = "91234569",
                Gender = "Male",
                StartDate = DateTime.Now.AddDays(-1),
                Cafe = cafe2
            };

            await employees.InsertManyAsync(new[] { employee1, employee2, employee3 });
        }
    }

}
