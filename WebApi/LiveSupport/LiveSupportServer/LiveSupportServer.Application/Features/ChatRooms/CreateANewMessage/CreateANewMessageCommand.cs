using MediatR;

namespace LiveSupportServer.Application.Features.ChatRooms.CreateANewMessage;
public sealed record CreateANewMessageCommand(
    string ChatRoomId,
    string NameLastname,
    string Message) : IRequest;