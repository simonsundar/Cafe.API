using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GICCafe.Domain.Entities
{
    // Core/Entities/Employee.cs
    public class Employee
    {
        public string Id { get; set; } // Unique identifier in 'UIXXXXXXX' format
        public string Name { get; set; }
        public string EmailAddress { get; set; }
        public string PhoneNumber { get; set; }
        public string Gender { get; set; }
        public Cafe Cafe { get; set; }
        public DateTime StartDate { get; set; }
    }
}
