using LiveSupportServer.Application.Features.Auths.Login;
using LiveSupportServer.Application.Features.Auths.Register;
using LiveSupportServer.WebApi.Abstractions;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace LiveSupportServer.WebApi.Controllers;
public class AuthController : ApiController
{   
    public AuthController(IMediator mediator): base(mediator)
    {
        
    }

    [HttpPost]
    public async Task<IActionResult> Register(RegisterCommand request, CancellationToken cancellationToken)
    {
        await _mediator.Send(request, cancellationToken);
        return NoContent();
    }

    [HttpPost]
    public async Task<IActionResult> Login(LoginCommand request, CancellationToken cancellationToken)
    {
       var token = await _mediator.Send(request, cancellationToken);
        return Ok(new { Token = token });
    }
}
