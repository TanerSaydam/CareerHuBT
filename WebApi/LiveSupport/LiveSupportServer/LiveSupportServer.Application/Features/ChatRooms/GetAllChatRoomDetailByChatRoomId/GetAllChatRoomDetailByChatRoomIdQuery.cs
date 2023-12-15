using LiveSupportServer.Domain.ChatDetails;
using LiveSupportServer.Domain.ChatRooms;
using MediatR;

namespace LiveSupportServer.Application.Features.ChatRooms.GetAllChatRoomDetailByChatRoomId;
public sealed record GetAllChatRoomDetailByChatRoomIdQuery(
    string ChatRoomId) : IRequest<ChatRoom?>;