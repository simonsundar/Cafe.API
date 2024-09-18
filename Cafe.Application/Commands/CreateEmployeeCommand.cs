using System;
using System.Collections.Generic;
using System.Linq;
using MediatR;
using System.Text;
using System.Threading.Tasks;
using GICCafe.Domain.Intefaces;
using GICCafe.Application.DTOs;
using GICCafe.Domain.Entities;

namespace GICCafe.Application.Commands
{
    // Application/Features/Employee/Commands/CreateEmployeeCommand.cs
    public class CreateEmployeeCommand : IRequest
    {
        public Employee Employee { get; set; }
    }

    // Application/Features/Employee/Commands/CreateEmployeeHandler.cs
    // Application/Features/Employee/Commands/CreateEmployeeHandler.cs
    public class CreateEmployeeHandler : IRequestHandler<CreateEmployeeCommand>
    {
        private readonly IEmployeeRepository _employeeRepository;
        private readonly ICafeRepository _cafeRepository;

        public CreateEmployeeHandler(IEmployeeRepository employeeRepository, ICafeRepository cafeRepository)
        {
            _employeeRepository = employeeRepository;
            _cafeRepository = cafeRepository;
        }


        async Task IRequestHandler<CreateEmployeeCommand>.Handle(CreateEmployeeCommand request, CancellationToken cancellationToken)
        {
            var cafe = await _cafeRepository.GetByIdAsync(request.Employee.Cafe?.Id);

            if (cafe == null)
            {
                throw new ArgumentException("Cafe not found.");
            }

            var existingEmployee = await _employeeRepository.GetByIdAsync(request.Employee.Id);
            if (existingEmployee != null)
            {
                throw new ArgumentException("Employee already exists.");
            }

            await _employeeRepository.CreateAsync(request.Employee);

        }
    }

}
