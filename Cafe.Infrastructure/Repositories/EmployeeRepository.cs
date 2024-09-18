using GICCafe.Domain.Entities;
using GICCafe.Domain.Intefaces;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GICCafe.Infrastructure.Repositories
{
    // Infrastructure/Repositories/EmployeeRepository.cs
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly IMongoCollection<Employee> _collection;

        public EmployeeRepository(IMongoDatabase database)
        {
            _collection = database.GetCollection<Employee>("employees");
        }

        public async Task<Employee> GetByIdAsync(string id)
        {
            return await _collection.Find(e => e.Id == id).FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<Employee>> GetByCafeAsync(string cafeId)
        {
            return await _collection.Find(e => e.Cafe.Id == cafeId).ToListAsync();
        }

        public async Task CreateAsync(Employee employee)
        {
            await _collection.InsertOneAsync(employee);
        }

        public async Task UpdateAsync(Employee employee)
        {
            await _collection.ReplaceOneAsync(e => e.Id == employee.Id, employee);
        }

        public async Task DeleteAsync(string id)
        {
            await _collection.DeleteOneAsync(e => e.Id == id);
        }
    }

  

}
