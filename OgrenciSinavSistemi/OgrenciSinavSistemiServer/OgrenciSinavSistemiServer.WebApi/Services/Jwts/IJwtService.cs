using OgrenciSinavSistemiServer.WebApi.Models.Users;

namespace OgrenciSinavSistemiServer.WebApi.Services.Jwts;

public interface IJwtService
{
    string CreateToken(User user);
}
