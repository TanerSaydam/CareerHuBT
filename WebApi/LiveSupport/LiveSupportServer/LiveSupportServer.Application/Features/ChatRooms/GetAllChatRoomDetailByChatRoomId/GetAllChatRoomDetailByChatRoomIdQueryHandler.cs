using LiveSupportServer.Domain.ChatDetails;
using LiveSupportServer.Domain.ChatRooms;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LiveSupportServer.Application.Features.ChatRooms.GetAllChatRoomDetailByChatRoomId;

internal sealed class GetAllChatRoomDetailByChatRoomIdQueryHandler : IRequestHandler<GetAllChatRoomDetailByChatRoomIdQuery, ChatRoom>
{
    private readonly IChatRoomRepository _chatRoomRepository;

    public GetAllChatRoomDetailByChatRoomIdQueryHandler(IChatRoomRepository chatRoomRepository)
    {
        _chatRoomRepository = chatRoomRepository;
    }

    public async Task<ChatRoom> Handle(GetAllChatRoomDetailByChatRoomIdQuery request, CancellationToken cancellationToken)
    {
        ChatRoom chatRoom = await _chatRoomRepository.GetChatRoomWithDetailByChatRoomIdAsync(request.ChatRoomId, cancellationToken);

        return chatRoom;
    }
}