using MediatR;

namespace LiveSupportServer.Application.Features.ChatRooms.CreateChatRoom;
public sealed record CreateChatRoomCommand(
    string NameLastname,
    string Subject) : IRequest<string>;