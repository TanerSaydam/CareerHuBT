using LiveSupportServer.Application.Abstractions;
using LiveSupportServer.Domain.Users;
using LiveSupportServer.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

namespace LiveSupportServer.Infrastructure.Repositories;

internal sealed class UserRepository : IUserRepository
{
    private readonly ApplicationDbContext _context;
    private readonly IJwtProvider _jwtProvider;
    public UserRepository(ApplicationDbContext context, IJwtProvider jwtProvider)
    {
        _context = context;
        _jwtProvider = jwtProvider;
    }

    public async Task<User> GetByIdAsync(string id, CancellationToken cancellationToken = default)
    {
        return await _context.Set<User>().FindAsync(id, cancellationToken);
    }

    public async Task<string> LoginAsync(string userName, string password, CancellationToken cancellationToken = default)
    {
        var user = await _context.Set<User>().Where(p=> p.UserName == new UserName(userName)).FirstOrDefaultAsync(cancellationToken);
        if (user is null)
        {
            throw new ArgumentException("Kullanıcı bulunamadı!");
        }

        var isPasswordRight = User.CheckThatUserPasswordIsCorrect(user, password);
        if (!isPasswordRight)
        {
            throw new ArgumentException("Şifre yanlış!");
        }

        string token = _jwtProvider.CreateToken(user);
        return token;
    }

    public async Task RegisterAsync(string name, string userName, string password, CancellationToken cancellationToken = default)
    {
        bool checkUserExsist = await _context.Set<User>().AnyAsync(p => p.UserName == new UserName(userName), cancellationToken);

        if (checkUserExsist)
        {
            throw new ArgumentException("Bu kullanıcı adı daha önce kullanılmış!");
        }

        User user = User.Create(name, userName, password);
        await _context.AddAsync(user, cancellationToken);
        await _context.SaveChangesAsync();
    }
}