using Microsoft.EntityFrameworkCore;
using OgrenciSinavSistemiServer.WebApi.Context;
using OgrenciSinavSistemiServer.WebApi.Models;

namespace OgrenciSinavSistemiServer.WebApi.Repositories;

public sealed class UserRepository(ApplicationDbContext context) : IUserRepository
{
    public async Task<User?> GetByUserNameAsync(string userName, CancellationToken cancellationToken = default)
    {
        return await context.Users.Where(p => p.UserName == userName).FirstOrDefaultAsync(cancellationToken);
    }
}
