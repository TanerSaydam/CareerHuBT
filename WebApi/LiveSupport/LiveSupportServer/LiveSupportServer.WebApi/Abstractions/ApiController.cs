using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace LiveSupportServer.WebApi.Abstractions;
[Route("api/[controller]/[action]")]
[ApiController]
public abstract class ApiController : ControllerBase
{
    protected readonly IMediator _mediator;

    protected ApiController(IMediator mediator)
    {
        _mediator = mediator;
    }
}
