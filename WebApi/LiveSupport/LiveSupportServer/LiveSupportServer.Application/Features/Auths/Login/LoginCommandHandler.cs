using LiveSupportServer.Domain.Users;
using MediatR;

namespace LiveSupportServer.Application.Features.Auths.Login;

internal sealed class LoginCommandHandler : IRequestHandler<LoginCommand, string>
{
    private readonly IUserRepository _userRepository;

    public LoginCommandHandler(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    public async Task<string> Handle(LoginCommand request, CancellationToken cancellationToken)
    {
        string token = await _userRepository.LoginAsync(request.UserName, request.Password, cancellationToken);
        return token;
    }
}