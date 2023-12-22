using ErrorOr;
using OgrenciSinavSistemiServer.WebApi.DTOs;

namespace OgrenciSinavSistemiServer.WebApi.Models.Users;

public interface IAuthService
{
    Task<ErrorOr<string?>> LoginAsync(LoginDto request, CancellationToken cancellationToken = default);
}
