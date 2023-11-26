using LiveSupportServer.Domain.Abstracts;
using LiveSupportServer.Domain.ChatRooms;
using MediatR;

namespace LiveSupportServer.Application.Features.ChatRooms.CreateChatRoom;

internal sealed class CreateChatRoomCommandHandler : IRequestHandler<CreateChatRoomCommand, string>
{
    private readonly IChatRoomRepository _chatRoomRepository;
    private readonly IUnitOfWork _unitOfWork;

    public CreateChatRoomCommandHandler(IChatRoomRepository chatRoomRepository, IUnitOfWork unitOfWork)
    {
        _chatRoomRepository = chatRoomRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task<string> Handle(CreateChatRoomCommand request, CancellationToken cancellationToken)
    {
        int number = await _chatRoomRepository.CreateChatRoomNumberAsync(cancellationToken);
        string id = await _chatRoomRepository.CreateChatRoomAsync(number, request.NameLastname, request.Subject, cancellationToken);
        await _unitOfWork.SaveChangesAsync(cancellationToken);

        return id;
    }
}