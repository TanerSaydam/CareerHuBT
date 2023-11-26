using LiveSupportServer.Application.Abstracts;
using LiveSupportServer.Domain.Abstracts;
using LiveSupportServer.Domain.ChatRooms;
using MediatR;

namespace LiveSupportServer.Application.Features.ChatRooms.CreateANewMessage;

internal sealed class CreateANewMessageCommandHandler : IRequestHandler<CreateANewMessageCommand>
{
    private readonly IChatRoomRepository _chatRoomRepository;
    private readonly IUnitOfWork _unitOfWork;
    private readonly ISignalRService _signalRService;

    public CreateANewMessageCommandHandler(IChatRoomRepository chatRoomRepository, IUnitOfWork unitOfWork, ISignalRService signalRService)
    {
        _chatRoomRepository = chatRoomRepository;
        _unitOfWork = unitOfWork;
        _signalRService = signalRService;
    }

    public async Task Handle(CreateANewMessageCommand request, CancellationToken cancellationToken)
    {
        ChatRoom chatRoom = await _chatRoomRepository.CreateANewMessageAsync(request.ChatRoomId, request.NameLastname, request.Message, cancellationToken);
        await _unitOfWork.SaveChangesAsync(cancellationToken);

        await _signalRService
                .SendNewMessageToConnections(
                                        request.ChatRoomId,
                                        chatRoom.ChatRoomDetails
                                                    .OrderBy(p => p.CreatedDate)
                                                    .LastOrDefault());
    }
}