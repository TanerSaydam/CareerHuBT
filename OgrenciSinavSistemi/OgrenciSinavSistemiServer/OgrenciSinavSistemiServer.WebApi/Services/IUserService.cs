using OgrenciSinavSistemiServer.WebApi.DTOs;

namespace OgrenciSinavSistemiServer.WebApi.Services;

public interface IUserService
{
    Task<string?> LoginAsync(LoginDto request, CancellationToken cancellationToken = default);
}
