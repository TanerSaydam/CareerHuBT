using OgrenciSinavSistemiServer.WebApi.DTOs;
using OgrenciSinavSistemiServer.WebApi.Models;
using OgrenciSinavSistemiServer.WebApi.Repositories;

namespace OgrenciSinavSistemiServer.WebApi.Services;

public sealed class UserService(IUserRepository userRepository, IJwtService jwtService) : IUserService
{
    public async Task<string?> LoginAsync(LoginDto request, CancellationToken cancellationToken = default)
    {
        User? user = await userRepository.GetByUserNameAsync(request.UserName, cancellationToken);

        if (user is null)
        {
            throw new ArgumentException("Kullanıcı bulunamadı");
        }

        string token = jwtService.CreateToken(user);
        return token;
    }
}
