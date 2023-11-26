using LiveSupportServer.Domain.ChatDetails;

namespace LiveSupportServer.Application.Abstracts;
public interface ISignalRService
{ 
    Task SendNewMessageToConnections(string chatRoomId, ChatRoomDetail detail);
}
