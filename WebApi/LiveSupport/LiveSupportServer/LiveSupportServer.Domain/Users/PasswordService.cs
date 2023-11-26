using System.Text;

namespace LiveSupportServer.Domain.Users;

public static class PasswordService
{
    public static void CreatePassword(string password, out byte[] passwordSalt, out byte[] passwordHash)
    {
        using var hmac = new System.Security.Cryptography.HMACSHA512();
        passwordSalt = hmac.Key;
        passwordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(password));
    }

    public static bool CheckPassword(string password, byte[] passwordSalt, byte[] passwordHash)
    {
        using var hmac = new System.Security.Cryptography.HMACSHA512(passwordSalt);
        //546a8wda1
        var computedHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(password));
        //asd 54s6dad
        for (int i = 0; i < computedHash.Length; i++)
        {
            if (computedHash[i] != passwordHash[i]) return false;
        }

        return true;
    }
}