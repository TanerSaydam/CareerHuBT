namespace LiveSupportServer.Domain.Users;

public interface IUserRepository
{
    Task RegisterAsync(string name, string userName, string password, CancellationToken cancellationToken = default);

    Task<string> LoginAsync(string userName, string password, CancellationToken cancellationToken = default);

    Task<User?> GetByIdAsync(string id, CancellationToken cancellationToken = default);
}