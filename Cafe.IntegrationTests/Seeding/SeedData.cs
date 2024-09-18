
namespace GICCafe.IntegrationTests.Seeding
{
    using System;
    using System.Collections.Generic;
    using MongoDB.Driver;
    using Newtonsoft.Json;
    using System.IO;
    using GICCafe.Domain.Entities;
    using GICCafe.Infrastructure.Repositories;

    public class SeedData
    {
        public static async Task Initialize(IMongoDatabase database)
        {

            // Create sample cafes
            var cafes = new List<Cafe>
        {
            new Cafe { Id = "1", Name = "cafe1", Description = "Great Cafe", Location = "Downtown" },
            new Cafe { Id = "2", Name = "cafe2", Description = "Nice Cafe", Location = "Uptown" }
        };


            // Create sample employees
            var employees = new List<Employee>
        {
            new Employee
            {
                 Name = "John Doe",
                EmailAddress = "john.doe@example.com",
                PhoneNumber = "91234567",
                Gender = "Male",
                Id = "Cafe123",
                StartDate = DateTime.UtcNow.AddDays(-10)
            },
            new Employee
            {
                 Name = "Jane Doe",
                EmailAddress = "jane.doe@example.com",
                PhoneNumber = "81234567",
                Gender = "Female",
                Id = "Cafe123",
                StartDate = DateTime.UtcNow.AddDays(-5)
            }
        };


            var employeesCollection = database.GetCollection<Employee>("Employees");
            var cafesCollection = database.GetCollection<Cafe>("Cafes");

            if (!employeesCollection.AsQueryable().Any() && !cafesCollection.AsQueryable().Any())
            {


                employeesCollection.InsertMany(employees);
                cafesCollection.InsertMany(cafes);

            }
        }
    }


}
