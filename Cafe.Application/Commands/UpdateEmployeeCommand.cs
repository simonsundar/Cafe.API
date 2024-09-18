using GICCafe.Domain.Entities;
using GICCafe.Domain.Intefaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GICCafe.Application.Commands
{
    // Application/Features/Employee/Commands/UpdateEmployeeCommand.cs
    public class UpdateEmployeeCommand : IRequest
    {
        public Employee Employee { get; set; }
    }

    // Application/Features/Employee/Commands/UpdateEmployeeHandler.cs
    public class UpdateEmployeeHandler : IRequestHandler<UpdateEmployeeCommand>
    {
        private readonly IEmployeeRepository _employeeRepository;
        private readonly ICafeRepository _cafeRepository;

        public UpdateEmployeeHandler(IEmployeeRepository employeeRepository, ICafeRepository cafeRepository)
        {
            _employeeRepository = employeeRepository;
            _cafeRepository = cafeRepository;
        }


        async Task IRequestHandler<UpdateEmployeeCommand>.Handle(UpdateEmployeeCommand request, CancellationToken cancellationToken)
        {
            var cafe = await _cafeRepository.GetByIdAsync(request.Employee.Cafe?.Id);

            if (cafe == null)
            {
                throw new ArgumentException("Cafe not found.");
            }

            var existingEmployee = await _employeeRepository.GetByIdAsync(request.Employee.Id);
            if (existingEmployee == null)
            {
                throw new ArgumentException("Employee not found.");
            }

            await _employeeRepository.UpdateAsync(request.Employee);
        }
    }


}
