using EmployeePortal.Services.Employees.Commands;
using EmployeePortal.Services.Employees.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ApiExplorer;

namespace EmployeePortal.Api.Controllers.V1
{
    [ApiController]
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/employees")]
    public sealed class EmployeesController(IMediator mediator) : ControllerBase
    {
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateEmployee cmd, CancellationToken ct)
        {
            var dto = await mediator.Send(cmd, ct);
            return CreatedAtAction(nameof(GetById), new
            {
                id = dto.Id,
                version = HttpContext.GetRequestedApiVersion()?.ToString()
            }, dto);
        }

        [HttpGet("{id:guid}")]
        public async Task<IActionResult> GetById(Guid id, CancellationToken ct)
        {
            var dto = await mediator.Send(new GetEmployeeById(id), ct);
            return dto is null ? NotFound() : Ok(dto);
        }

        [HttpGet]
        public async Task<IActionResult> Search([FromQuery] string? q, [FromQuery] int page = 1, [FromQuery] int pageSize = 20, CancellationToken ct = default)
            => Ok(await mediator.Send(new SearchEmployees(q, page, pageSize), ct));
    }
}
