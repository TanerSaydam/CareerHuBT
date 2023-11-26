using LiveSupportServer.Domain.Abstracts;
using LiveSupportServer.Domain.ChatRooms;
using LiveSupportServer.Domain.Users;

namespace LiveSupportServer.Domain.ChatDetails;

public sealed class ChatRoomDetail : Entity
{
    public ChatRoomDetail(string id, string chatRoomId, string nameLastname, string message, DateTime createdDate) : base(id)
    {
        ChatRoomId = chatRoomId;
        NameLastname = nameLastname;
        Message = message;
        CreatedDate = createdDate;
    }

    public string ChatRoomId { get; private set; }
    public string NameLastname { get; private set; }
    public string Message { get; private set; }
    public DateTime CreatedDate { get; private set; }
}