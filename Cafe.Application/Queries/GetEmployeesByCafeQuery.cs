using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GICCafe.Domain.Intefaces;
using GICCafe.Domain.Entities;
using GICCafe.Application.DTOs;
namespace GICCafe.Application.Queries
{

    // Application/Features/Employee/Queries/GetEmployeesByCafeQuery.cs
    public class GetEmployeesByCafeQuery : IRequest<IEnumerable<EmployeeDto>>
    {
        public string CafeId { get; set; }
    }

    // Application/Features/Employee/Queries/GetEmployeesByCafeHandler.cs
    public class GetEmployeesByCafeHandler : IRequestHandler<GetEmployeesByCafeQuery, IEnumerable<EmployeeDto>>
    {
        private readonly IEmployeeRepository _repository;

        public GetEmployeesByCafeHandler(IEmployeeRepository repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<EmployeeDto>> Handle(GetEmployeesByCafeQuery request, CancellationToken cancellationToken)
        {
            var employees = await _repository.GetByCafeAsync(request.CafeId);
            return employees.Select(e => new EmployeeDto
            {
                Id = e.Id,
                Name = e.Name,
                EmailAddress = e.EmailAddress,
                PhoneNumber = e.PhoneNumber,
                DaysWorked = (DateTime.Now - e.StartDate).Days,
                Cafe = e.Cafe?.Name
            });
        }
    }
}
