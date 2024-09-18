using GICCafe.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GICCafe.Domain.Intefaces
{
    // Core/Interfaces/ICafeRepository.cs
    public interface ICafeRepository
    {
        Task<Cafe> GetByIdAsync(string id);
        Task<IEnumerable<Cafe>> GetByLocationAsync(string location);
        Task CreateAsync(Cafe cafe);
        Task UpdateAsync(Cafe cafe);
        Task DeleteAsync(string id);
    }
}
