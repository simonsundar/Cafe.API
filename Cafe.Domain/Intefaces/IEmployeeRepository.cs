using GICCafe.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GICCafe.Domain.Intefaces
{
    // Core/Interfaces/IEmployeeRepository.cs
    public interface IEmployeeRepository
    {
        Task<Employee> GetByIdAsync(string id);
        Task<IEnumerable<Employee>> GetByCafeAsync(string cafeId);
        Task CreateAsync(Employee employee);
        Task UpdateAsync(Employee employee);
        Task DeleteAsync(string id);
    }
}
