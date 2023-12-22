using ErrorOr;
using OgrenciSinavSistemiServer.WebApi.DTOs;
using OgrenciSinavSistemiServer.WebApi.Services.Jwts;

namespace OgrenciSinavSistemiServer.WebApi.Models.Users;

public sealed class AuthService(
    IUserRepository userRepository,
    IJwtService jwtService
    ) : IAuthService
{

    public async Task<ErrorOr<string?>> LoginAsync(LoginDto request, CancellationToken cancellationToken = default)
    {
        User? user = await userRepository.GetByUserNameAsync(request.UserName, cancellationToken);

        if (user is null)
        {
            return Error.NotFound("UserNotFound", "Kullanıcı bulunamadı");
        }

        string token = jwtService.CreateToken(user);
        return token;
    }
}
