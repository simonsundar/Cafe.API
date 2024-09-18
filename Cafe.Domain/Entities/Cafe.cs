using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GICCafe.Domain.Entities
{
    public class Cafe
    {
        public string Id { get; set; } // UUID
        public string Name { get; set; }
        public string Description { get; set; }
        public string Logo { get; set; } // Optional
        public string Location { get; set; }
        public List<Employee> Employees { get; set; } = new List<Employee>();
    }
}
