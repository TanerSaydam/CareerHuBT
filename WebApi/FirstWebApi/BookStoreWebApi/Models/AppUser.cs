using Microsoft.AspNetCore.Identity;

namespace BookStoreWebApi.Models;

public sealed class AppUser : IdentityUser<string>
{
    public AppUser()
    {
        Id = Ulid.NewUlid().ToString();
    }

    public string NameLastname { get; set; }
    public string IdentityNumber { get; set; }
    public bool IsAdmin { get; set; }
    public string RefreshToken { get; set; }
    public DateTime RefreshTokenExpires { get; set; }
}