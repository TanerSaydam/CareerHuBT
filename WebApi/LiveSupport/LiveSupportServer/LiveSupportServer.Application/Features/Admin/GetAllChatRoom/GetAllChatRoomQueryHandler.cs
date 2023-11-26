using LiveSupportServer.Domain.ChatRooms;
using MediatR;

namespace LiveSupportServer.Application.Features.Admin.GetAllChatRoom;

internal sealed class GetAllChatRoomQueryHandler : IRequestHandler<GetAllChatRoomQuery, List<ChatRoom>>
{
    private readonly IChatRoomRepository _chatRoomRepository;

    public GetAllChatRoomQueryHandler(IChatRoomRepository chatRoomRepository)
    {
        _chatRoomRepository = chatRoomRepository;
    }

    public async Task<List<ChatRoom>> Handle(GetAllChatRoomQuery request, CancellationToken cancellationToken)
    {
        return await _chatRoomRepository.GetChatRoomsAsync(cancellationToken);
    }
}
