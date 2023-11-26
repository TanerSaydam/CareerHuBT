using LiveSupportServer.Domain.ChatDetails;
using LiveSupportServer.Domain.ChatRooms;
using LiveSupportServer.Infrastructure.Context;
using LiveSupportServer.Infrastructure.Hubs;
using Microsoft.AspNetCore.SignalR;
using Microsoft.EntityFrameworkCore;

namespace LiveSupportServer.Infrastructure.Repositories;

internal sealed class ChatRoomRepository : IChatRoomRepository
{
    private readonly ApplicationDbContext _context;
    private readonly IHubContext<CreateRoomHub> _hubContext;

    public ChatRoomRepository(ApplicationDbContext context, IHubContext<CreateRoomHub> hubContext)
    {
        _context = context;
        _hubContext = hubContext;
    }

    public async Task<ChatRoom> CreateANewMessageAsync(string chatRoomId, string nameLastname, string message, CancellationToken cancellationToken)
    {
        ChatRoom chatRoom =
            await _context
            .Set<ChatRoom>()
            .Where(p => p.Id == chatRoomId)
            .Include(p => p.ChatRoomDetails)
            .FirstOrDefaultAsync(cancellationToken);

        if (chatRoom is null)
        {
            throw new Exception("Sohbet odası bulunamadı!");
        }

        chatRoom.CreateANewAnswer(nameLastname, message);

        return chatRoom;
    }

    public async Task<string> CreateChatRoomAsync(int number, string clientNameLastname, string subject, CancellationToken cancellationToken = default)
    {
        string id = Ulid.NewUlid().ToString();
        ChatRoom chatRoom = new(id, number, clientNameLastname, subject);
        chatRoom.CreateChatRoomDetail(clientNameLastname, subject, DateTime.UtcNow);
        chatRoom.CreateChatRoomDetail("AI Support", "Mesajınız sisteme işlendi. Birazdan müşteri temsilcimiz ile görüşeceksiniz. Lütfen bu ekranı kapatmayın.", DateTime.UtcNow.AddSeconds(1));
        await _context.Set<ChatRoom>().AddAsync(chatRoom, cancellationToken);

        await _hubContext.Clients.All.SendAsync("CreateRoom", chatRoom);

        return id;
    }

    public async Task<int> CreateChatRoomNumberAsync(CancellationToken cancellationToken = default)
    {
        ChatRoom chatRoom =
            await _context
                .Set<ChatRoom>()
                .OrderBy(p => p.CreatedDate)
                .LastOrDefaultAsync(cancellationToken);

        if (chatRoom is null) return 1;

        return chatRoom.Number + 1;
    }

    public async Task<ChatRoom?> GetChatRoomByIdAsync(string id, CancellationToken cancellationToken = default)
    {
        return await _context.Set<ChatRoom>()
            .Where(p=> p.Id == id)
            .Include(p=> p.ChatRoomDetails)
            .FirstOrDefaultAsync(cancellationToken);
    }

    public async Task<List<ChatRoom>> GetChatRoomsAsync(CancellationToken cancellationToken = default)
    {
        return 
            await _context.Set<ChatRoom>()
                    .Where(p => p.IsClosed == false)
                    .Include(p=> p.User)
                    .AsNoTracking()
                    .OrderByDescending(p => p.LastAnswerDate)
                    .ToListAsync(cancellationToken);
    }

    public async Task<ChatRoom> GetChatRoomWithDetailByChatRoomIdAsync(string chatRoomId, CancellationToken cancellationToken)
    {
        var chat = await _context
            .Set<ChatRoom>()
            .Where(p => p.Id == chatRoomId)
            .Include(p => p.ChatRoomDetails)
            .Include(p=> p.User)
            .FirstOrDefaultAsync(cancellationToken);

        if (chat is not null)
        {
            chat.OrderChatRoomDetails();
        }        

        return chat;
    }
}