using OgrenciSinavSistemiServer.WebApi.Models;

namespace OgrenciSinavSistemiServer.WebApi.Models.Users;

public interface IUserRepository
{
    Task<User?> GetByUserNameAsync(string userName, CancellationToken cancellationToken = default);
    Task CreateAsync(User user, CancellationToken cancellationToken = default);
    IQueryable<User> GetAll();
}
