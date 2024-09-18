using GICCafe.Domain.Intefaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GICCafe.Application.Commands
{
    // Application/Features/Cafe/Commands/DeleteCafeCommand.cs
    public class DeleteCafeCommand : IRequest
    {
        public string Id { get; set; }
    }


    // Application/Features/Cafe/Commands/DeleteCafeHandler.cs
    public class DeleteCafeHandler : IRequestHandler<DeleteCafeCommand>
    {
        private readonly ICafeRepository _cafeRepository;
        private readonly IEmployeeRepository _employeeRepository;

        public DeleteCafeHandler(ICafeRepository cafeRepository, IEmployeeRepository employeeRepository)
        {
            _cafeRepository = cafeRepository;
            _employeeRepository = employeeRepository;
        }

        async Task IRequestHandler<DeleteCafeCommand>.Handle(DeleteCafeCommand request, CancellationToken cancellationToken)
        {
            var employees = await _employeeRepository.GetByCafeAsync(request.Id);
            foreach (var employee in employees)
            {
                await _employeeRepository.DeleteAsync(employee.Id);
            }
            await _cafeRepository.DeleteAsync(request.Id);
        }
    }

}
