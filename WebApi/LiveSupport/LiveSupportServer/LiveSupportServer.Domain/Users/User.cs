using LiveSupportServer.Domain.Abstracts;
using LiveSupportServer.Domain.Shared.ValueObjects;

namespace LiveSupportServer.Domain.Users;

public sealed class User : Entity //Rich Domain Model
{
    //factory pattern
    private User(
        string id,
        Name name,
        UserName userName,
        byte[] passwordSalt,
        byte[] passwordHash) : base(id)
    {
        Name = name;
        UserName = userName;
        PasswordSalt = passwordSalt;
        PasswordHash = passwordHash;
    }

    private User() : base(Guid.NewGuid().ToString())
    {
    }

    public Name Name { get; private set; }
    public UserName UserName { get; private set; }
    public byte[] PasswordSalt { get; private set; }
    public byte[] PasswordHash { get; private set; }

    public static User Create(string name, string userName, string password) //factory
    {
        byte[] passwordSalt;
        byte[] passwordHash;

        PasswordService.CreatePassword(password, out passwordSalt, out passwordHash);

        User user = new(
            id: Ulid.NewUlid().ToString(),
            name: new(name),
            userName: new(userName),
            passwordSalt: passwordSalt,
            passwordHash: passwordHash);

        return user;
    }

    public static bool CheckThatUserPasswordIsCorrect(User user, string password)
    {
        bool result = PasswordService.CheckPassword(password, user.PasswordSalt, user.PasswordHash);

        return result;
    }
}