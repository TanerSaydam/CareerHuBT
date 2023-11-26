using LiveSupportServer.Application.Features.ChatRooms.CreateANewMessage;
using LiveSupportServer.Application.Features.ChatRooms.CreateChatRoom;
using LiveSupportServer.Application.Features.ChatRooms.GetAllChatRoomDetailByChatRoomId;
using LiveSupportServer.WebApi.Abstractions;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace LiveSupportServer.WebApi.Controllers;

public class ChatRoomsController : ApiController
{
    public ChatRoomsController(IMediator mediator) : base(mediator)
    {
    }

    [HttpPost]
    public async Task<IActionResult> CreateChatRoom(CreateChatRoomCommand request, CancellationToken cancellationToken)
    {
        string id = await _mediator.Send(request, cancellationToken);
        return Ok(new { ChatRoomId = id });
    }

    [HttpPost]
    public async Task<IActionResult> GetAllChatRoomDetailByChatId(GetAllChatRoomDetailByChatRoomIdQuery request, CancellationToken cancellationToken)
    {
        var response = await _mediator.Send(request, cancellationToken);
        return Ok(response);
    }

    [HttpPost]
    public async Task<IActionResult> CreateANewMessage(CreateANewMessageCommand request, CancellationToken cancellationToken)
    {
        await _mediator.Send(request, cancellationToken);
        return NoContent();
    }
}