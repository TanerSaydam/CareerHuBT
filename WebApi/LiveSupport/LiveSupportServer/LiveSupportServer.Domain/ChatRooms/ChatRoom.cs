using LiveSupportServer.Domain.Abstracts;
using LiveSupportServer.Domain.ChatDetails;
using LiveSupportServer.Domain.Shared.ValueObjects;
using LiveSupportServer.Domain.Users;

namespace LiveSupportServer.Domain.ChatRooms;

public sealed class ChatRoom : Entity
{
    public int Number { get; private set; } = 0;
    public Name ClientNameLastname { get; private set; } = new(string.Empty);
    public Subject Subject { get; private set; } = new(string.Empty);
    public DateTime CreatedDate { get; private set; } = DateTime.UtcNow;
    public bool IsClosed { get; private set; } = false;
    public Name? WhoIsTheLastAnswer { get; private set; }
    public DateTime? LastAnswerDate { get; private set; }
    public string? UserId { get; private set; }
    public User? User { get; private set; }
    public List<ChatRoomDetail>? ChatRoomDetails { get; private set; }

    private ChatRoom() : base(Guid.NewGuid().ToString())
    {
    }

    public ChatRoom(string id, int number, string clientNameLastname, string subject) : base(id)
    {
        Number = number;
        ClientNameLastname = new(clientNameLastname);
        Subject = new(subject);
        CreatedDate = DateTime.UtcNow;
        WhoIsTheLastAnswer = new(clientNameLastname);
        LastAnswerDate = DateTime.UtcNow;
        IsClosed = false;
        ChatRoomDetails = new();
    }

    //SOLID Prensipleri
    //Single Responsibility
    //Open-Closed
    //Liskov-subsition
    //Interface Segregtion
    //Dependency Inversion

    public void ConnectChatRoom(string userId)
    {
        if (IsClosed) throw new ArgumentException("Kapalı odaya bağlanamazsınız!");
        if (UserId is null) UserId = userId;
        else throw new ArgumentException("Bu odayı başka bir müşteri temsilcisi üstlenmiş!");
    }

    public void CreateANewAnswer(string nameLastname, string message)
    {
        //aggregate root işlemi
        if (IsClosed) throw new ArgumentException("Kapalı odaya mesaj yazamazsınız!");
        CreateChatRoomDetail(nameLastname, message, DateTime.UtcNow);

        ChangeLastAnswer(nameLastname);
    }

    public void CreateChatRoomDetail(string nameLastname, string message, DateTime createdDate)
    {
        ChatRoomDetail chatRoomDetail = new(
            id: Ulid.NewUlid().ToString(),
            chatRoomId: Id,
            nameLastname: nameLastname,
            message: message,
            createdDate: createdDate);

        if(ChatRoomDetails is not null)
        {
            ChatRoomDetails.Add(chatRoomDetail);
        }        
    }

    private void ChangeLastAnswer(string whoisTheLastAnswer)
    {
        WhoIsTheLastAnswer = new(whoisTheLastAnswer);
        LastAnswerDate = DateTime.UtcNow;
    }

    public void ChangeRoomStatus()
    {
        IsClosed = !IsClosed;
    }

    public void OrderChatRoomDetails()
    {
        ChatRoomDetails = ChatRoomDetails!.OrderBy(p => p.CreatedDate).ToList();
    }
}