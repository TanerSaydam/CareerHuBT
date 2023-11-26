using MediatR;
using Microsoft.AspNetCore.Mvc;
using RestaurantServer.Application.Features.Tables.CreateTable;
using RestaurantServer.Application.Features.Tables.GetAllTable;
using RestaurantServer.Application.Features.Tables.GetTableNumberById;

namespace RestaurantServer.WebApi.Controllers;
[Route("api/[controller]/[action]")]
[ApiController]
public class TablesController : ControllerBase
{
    private readonly IMediator _mediator;

    public TablesController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpPost]
    public async Task<IActionResult> Create(CreateTableCommand request, CancellationToken cancellationToken = default)
    {
        var response = await _mediator.Send(request, cancellationToken);
        if (response.IsError)
        {
            return BadRequest(response.FirstError);
        }

        return NoContent();
    }

    [HttpPost]
    public async Task<IActionResult> GetNumberById(GetTableNumberByIdQuery request, CancellationToken cancellationToken = default)
    {
        var response = await _mediator.Send(request, cancellationToken);

        return Ok(new { Number = response.Value });
    }

    [HttpPost]
    public async Task<IActionResult> GetAll(GetAllTableQuery request, CancellationToken cancellationToken = default)
    {
        var response = await _mediator.Send(request, cancellationToken);

        return Ok(response.Value);
    }
}
