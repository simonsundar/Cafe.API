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
    // Application/Features/Cafe/Commands/CreateCafeCommand.cs
    public class CreateCafeCommand : IRequest<bool>
    {
        public Cafe Cafe { get; set; }
    }

    // Application/Features/Cafe/Commands/CreateCafeHandler.cs
    public class CreateCafeCommandHandler : IRequestHandler<CreateCafeCommand, bool>
    {
        private readonly ICafeRepository _cafeRepository;

        public CreateCafeCommandHandler(ICafeRepository cafeRepository)
        {
            _cafeRepository = cafeRepository;
        }


        //public async Task IRequestHandler<CreateCafeCommand>.Handle(CreateCafeCommand request, CancellationToken cancellationToken)
        //{
        //    await _cafeRepository.CreateAsync(request.Cafe);
        //}

        public async Task<bool> Handle(CreateCafeCommand request, CancellationToken cancellationToken)
        {
            await _cafeRepository.CreateAsync(request.Cafe);
            return true;
        }
    }



}
