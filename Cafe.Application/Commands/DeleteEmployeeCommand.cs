using GICCafe.Domain.Intefaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GICCafe.Application.Commands
{
    // Application/Features/Employee/Commands/DeleteEmployeeCommand.cs
    public class DeleteEmployeeCommand : IRequest
    {
        public string Id { get; set; }
    }

    // Application/Features/Employee/Commands/DeleteEmployeeHandler.cs
    public class DeleteEmployeeHandler : IRequestHandler<DeleteEmployeeCommand>
    {
        private readonly IEmployeeRepository _employeeRepository;

        public DeleteEmployeeHandler(IEmployeeRepository employeeRepository)
        {
            _employeeRepository = employeeRepository;
        } 

        async Task IRequestHandler<DeleteEmployeeCommand>.Handle(DeleteEmployeeCommand request, CancellationToken cancellationToken)
        {
            await _employeeRepository.DeleteAsync(request.Id);
        }
    }


}
