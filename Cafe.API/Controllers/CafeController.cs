using MediatR;
using Microsoft.AspNetCore.Mvc;
using GICCafe.Application.Queries;
using GICCafe.Application.Commands;
using GICCafe.Domain.Entities;

namespace GICCafe.API.Controllers
{
    // API/Controllers/CafeController.cs
    [ApiController]
    [Route("[controller]")]
    public class CafeController : ControllerBase
    {
        private readonly IMediator _mediator;

        public CafeController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> Get([FromQuery] string location)
        {
            var query = new GetCafesByLocationQuery { Location = location };
            var cafes = await _mediator.Send(query);
            return Ok(cafes);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] Cafe cafe)
        {
            await _mediator.Send(new CreateCafeCommand { Cafe = cafe });
            return CreatedAtAction(nameof(Get), new { id = cafe.Id }, cafe);
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromBody] Cafe cafe)
        {
            await _mediator.Send(new UpdateCafeCommand { Cafe = cafe });
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(string id)
        {
            await _mediator.Send(new DeleteCafeCommand { Id = id });
            return NoContent();
        }
    }

}
