using GICCafe.Application.DTOs;
using GICCafe.Domain.Intefaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GICCafe.Application.Queries
{
    // Application/Features/Cafe/Queries/GetCafesByLocationQuery.cs
    public class GetCafesByLocationQuery : IRequest<IEnumerable<CafeDto>>
    {
        public string Location { get; set; }
    }


    // Application/Features/Cafe/Queries/GetCafesByLocationHandler.cs
    public class GetCafesByLocationQueryHandler : IRequestHandler<GetCafesByLocationQuery, IEnumerable<CafeDto>>
    {
        private readonly ICafeRepository _cafeRepository;
        private readonly IEmployeeRepository _employeeRepository;

        public GetCafesByLocationQueryHandler(ICafeRepository cafeRepository, IEmployeeRepository employeeRepository)
        {
            _cafeRepository = cafeRepository;
            _employeeRepository = employeeRepository;
        }

        public async Task<IEnumerable<CafeDto>> Handle(GetCafesByLocationQuery request, CancellationToken cancellationToken)
        {
            var cafes = await _cafeRepository.GetByLocationAsync(request.Location);

            var cafeDtos = new List<CafeDto>();

            foreach (var cafe in cafes)
            {
                var employeeCount = (await _employeeRepository.GetByCafeAsync(cafe.Id)).Count();
                cafeDtos.Add(new CafeDto
                {
                    Id = cafe.Id,
                    Name = cafe.Name,
                    Description = cafe.Description,
                    Logo = cafe.Logo,
                    Location = cafe.Location,
                    EmployeeCount = employeeCount
                });
            }

            // Sort cafes by the number of employees in descending order
            return cafeDtos.OrderByDescending(c => c.EmployeeCount);
        }
    }

}
