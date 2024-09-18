using GICCafe.Application.Commands;
using GICCafe.Application.Queries;
using GICCafe.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace GICCafe.API.Controllers
{
    // API/Controllers/EmployeeController.cs
    [ApiController]
    [Route("[controller]")]
    public class EmployeeController : ControllerBase
    {
        private readonly IMediator _mediator;

        public EmployeeController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> Get([FromQuery] string cafe)
        {
            var query = new GetEmployeesByCafeQuery { CafeId = cafe };
            var employees = await _mediator.Send(query);
            return Ok(employees);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] Employee employee)
        {
            await _mediator.Send(new CreateEmployeeCommand { Employee = employee });
            return CreatedAtAction(nameof(Get), new { id = employee.Id }, employee);
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromBody] Employee employee)
        {
            await _mediator.Send(new UpdateEmployeeCommand { Employee = employee });
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(string id)
        {
            await _mediator.Send(new DeleteEmployeeCommand { Id = id });
            return NoContent();
        }
    }

}
