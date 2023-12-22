using Microsoft.EntityFrameworkCore;
using OgrenciSinavSistemiServer.WebApi.Context;
using OgrenciSinavSistemiServer.WebApi.Models;

namespace OgrenciSinavSistemiServer.WebApi.Models.Users;

public sealed class UserRepository(ApplicationDbContext context) : IUserRepository
{
    public async Task CreateAsync(User user, CancellationToken cancellationToken = default)
    {
        await context.Users.AddAsync(user, cancellationToken);
    }

    public IQueryable<User> GetAll()
    {
        return context.Users.AsQueryable();
    }

    public async Task<User?> GetByUserNameAsync(string userName, CancellationToken cancellationToken = default)
    {
        return await context.Users.Where(p => p.UserName == userName).FirstOrDefaultAsync(cancellationToken);
    }
}
