using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GICCafe.Application.DTOs
{
    // Application/DTOs/CafeDto.cs
    public class CafeDto
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Logo { get; set; }
        public string Location { get; set; }
        public int EmployeeCount { get; set; }
    }
}
