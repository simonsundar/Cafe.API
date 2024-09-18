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
    // Application/Features/Cafe/Commands/UpdateCafeCommand.cs
    public class UpdateCafeCommand : IRequest
    {
        public Cafe Cafe { get; set; }
    }


    // Application/Features/Cafe/Commands/UpdateCafeHandler.cs
    public class UpdateCafeHandler : IRequestHandler<UpdateCafeCommand>
    {
        private readonly ICafeRepository _cafeRepository;

        public UpdateCafeHandler(ICafeRepository cafeRepository)
        {
            _cafeRepository = cafeRepository;
        }

        async Task IRequestHandler<UpdateCafeCommand>.Handle(UpdateCafeCommand request, CancellationToken cancellationToken)
        {
            await _cafeRepository.UpdateAsync(request.Cafe);
        }
    }

}
