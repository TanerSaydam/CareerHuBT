using LiveSupportServer.Domain.Users;
using MediatR;

namespace LiveSupportServer.Application.Features.Auths.Register;

internal sealed class RegisterCommandHandler : IRequestHandler<RegisterCommand>
{
    private readonly IUserRepository _userRepository;

    public RegisterCommandHandler(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    public async Task Handle(RegisterCommand request, CancellationToken cancellationToken)
    {
        await _userRepository.RegisterAsync(request.Name, request.UserName, request.Password, cancellationToken);
    }
}