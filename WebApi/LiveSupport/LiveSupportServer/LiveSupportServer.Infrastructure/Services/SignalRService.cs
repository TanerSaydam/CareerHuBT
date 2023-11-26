using LiveSupportServer.Application.Abstracts;
using LiveSupportServer.Domain.ChatDetails;
using LiveSupportServer.Infrastructure.Hubs;
using Microsoft.AspNetCore.SignalR;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace LiveSupportServer.Infrastructure.Services;
internal sealed class SignalRService : ISignalRService
{
    private readonly IHubContext<CreateRoomHub> _hubContext;

    public SignalRService(IHubContext<CreateRoomHub> hubContext)
    {
        _hubContext = hubContext;
    }

    public async Task SendNewMessageToConnections(string chatRoomId, ChatRoomDetail detail)
    {
        await _hubContext.Clients.Group(chatRoomId).SendAsync("Chat", detail);
    }
}
