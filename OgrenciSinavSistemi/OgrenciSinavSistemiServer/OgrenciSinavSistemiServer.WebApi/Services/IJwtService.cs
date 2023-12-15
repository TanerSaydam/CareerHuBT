using OgrenciSinavSistemiServer.WebApi.Models;

namespace OgrenciSinavSistemiServer.WebApi.Services;

public interface IJwtService
{
    string CreateToken(User user);
}
