using MediatR;

namespace LiveSupportServer.Application.Features.Admin.ConnectChatRoom;
public sealed record ConnectChatRoomCommand(
    string ChatRoomId,
    string UserId): IRequest;
