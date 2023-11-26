using LiveSupportServer.Domain.Users;

namespace LiveSupportServer.Application.Abstractions;
public interface IJwtProvider
{
    string CreateToken(User user);
}
