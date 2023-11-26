using LiveSupportServer.Application.Abstracts;
using LiveSupportServer.Domain.Abstracts;
using LiveSupportServer.Domain.ChatRooms;
using LiveSupportServer.Domain.Users;
using MediatR;

namespace LiveSupportServer.Application.Features.Admin.ConnectChatRoom;

internal sealed class ConnectChatRoomCommandHandler : IRequestHandler<ConnectChatRoomCommand>
{
    private readonly IChatRoomRepository _chatRoomRepository;
    private readonly IUserRepository _userRepository;
    private readonly IUnitOfWork _unitOfWork;
    private readonly ISignalRService _signalRService;
    public ConnectChatRoomCommandHandler(IChatRoomRepository chatRoomRepository, IUnitOfWork unitOfWork, IUserRepository userRepository, ISignalRService signalRService)
    {
        _chatRoomRepository = chatRoomRepository;
        _unitOfWork = unitOfWork;
        _userRepository = userRepository;
        _signalRService = signalRService;
    }

    public async Task Handle(ConnectChatRoomCommand request, CancellationToken cancellationToken)
    {
        ChatRoom chatRoom = await _chatRoomRepository.GetChatRoomByIdAsync(request.ChatRoomId, cancellationToken);
        if(chatRoom is null)
        {
            throw new ArgumentException("Sohbet odası bulunamadı!");
        }

        if (chatRoom.IsClosed)
        {
            throw new ArgumentException("Kapalı odaya giremezsiniz!");
        }

        if(chatRoom.UserId is not null && chatRoom.UserId != request.UserId)
        {
            throw new ArgumentException("Bu sohbet odasına başka bir yetkili bakıyor!");
        }

        if(chatRoom.UserId != request.UserId)
        {
            User user = await _userRepository.GetByIdAsync(request.UserId, cancellationToken);

            chatRoom.ConnectChatRoom(request.UserId);

            chatRoom.CreateANewAnswer(user.Name.Value, $"Merhaba ben {user.Name.Value}. Size nasıl yardımcı olabilirim?");
            await _unitOfWork.SaveChangesAsync(cancellationToken);

            await _signalRService
                .SendNewMessageToConnections(
                                        chatRoom.Id,
                                        chatRoom.ChatRoomDetails
                                                    .OrderBy(p => p.CreatedDate)
                                                    .LastOrDefault());
        }       
    }
}
