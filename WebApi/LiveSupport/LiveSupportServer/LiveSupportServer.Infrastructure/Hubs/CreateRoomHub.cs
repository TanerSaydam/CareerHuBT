using Microsoft.AspNetCore.SignalR;

namespace LiveSupportServer.Infrastructure.Hubs;
public sealed class CreateRoomHub : Hub
{
    public async Task JoinChatRoomAsync(string chatRoomId)
    {       
        await Groups.AddToGroupAsync(Context.ConnectionId, chatRoomId);
    }    

    public async Task LeaveChatRoomAsync(string chatRoomId)
    {
        await Groups.RemoveFromGroupAsync(Context.ConnectionId, chatRoomId);
    }
}
