using LiveSupportServer.Application.Features.Admin.ConnectChatRoom;
using LiveSupportServer.Application.Features.Admin.GetAllChatRoom;
using LiveSupportServer.WebApi.Abstractions;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace LiveSupportServer.WebApi.Controllers;
public class AdminController : ApiController
{
    public AdminController(IMediator mediator) : base(mediator)
    {
    }

    [HttpPost]
    public async Task<IActionResult> GetAllChatRoom(GetAllChatRoomQuery request, CancellationToken cancellationToken)
    {
        return Ok(await _mediator.Send(request, cancellationToken));
    }

    [HttpPost]
    public async Task<IActionResult> ConnectChatRoom(ConnectChatRoomCommand request, CancellationToken cancellationToken)
    {
        await _mediator.Send(request, cancellationToken);
        return NoContent();
    }
}
