namespace LiveSupportServer.Domain.ChatRooms;

public interface IChatRoomRepository
{
    Task<ChatRoom> CreateANewMessageAsync(string chatRoomId, string nameLastname, string message, CancellationToken cancellationToken);

    Task<string> CreateChatRoomAsync(int number, string clientNameLastname, string subject, CancellationToken cancellationToken = default);

    Task<int> CreateChatRoomNumberAsync(CancellationToken cancellationToken = default);

    Task<ChatRoom?> GetChatRoomWithDetailByChatRoomIdAsync(string chatRoomId, CancellationToken cancellationToken = default);

    Task<List<ChatRoom>> GetChatRoomsAsync(CancellationToken cancellationToken = default);

    Task<ChatRoom?> GetChatRoomByIdAsync(string id, CancellationToken cancellationToken = default);
}