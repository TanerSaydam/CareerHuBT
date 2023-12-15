using OgrenciSinavSistemiServer.WebApi.Models;

namespace OgrenciSinavSistemiServer.WebApi.Repositories;

public interface IUserRepository
{
    Task<User?> GetByUserNameAsync(string userName, CancellationToken cancellationToken =default);
}
