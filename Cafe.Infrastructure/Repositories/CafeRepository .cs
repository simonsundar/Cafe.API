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

    // Infrastructure/Repositories/CafeRepository.cs
    public class CafeRepository : ICafeRepository
    {
        private readonly IMongoCollection<Cafe> _collection;

        public CafeRepository(IMongoDatabase database)
        {
            _collection = database.GetCollection<Cafe>("cafes");
        }

        public async Task<Cafe> GetByIdAsync(string id)
        {
            return await _collection.Find(c => c.Id == id).FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<Cafe>> GetByLocationAsync(string location)
        {
            return await _collection.Find(c => c.Location == location).ToListAsync();
        }

        public async Task CreateAsync(Cafe cafe)
        {
            await _collection.InsertOneAsync(cafe);
        }

        public async Task UpdateAsync(Cafe cafe)
        {
            await _collection.ReplaceOneAsync(c => c.Id == cafe.Id, cafe);
        }

        public async Task DeleteAsync(string id)
        {
            await _collection.DeleteOneAsync(c => c.Id == id);
        }
    }


}
