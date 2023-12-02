using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace IdentityLibraryApp.Services;

public static class JwtService
{
    public static string CreateToken()
    {
        string token = string.Empty;

        List<Claim> claims = new List<Claim>();
        claims.Add(new(ClaimTypes.Role, "Admin"));
        claims.Add(new("UserId", "1111"));

        JwtSecurityToken jwtSecurityToken = new JwtSecurityToken(
            issuer: "Taner Saydam",
            audience: "Taner Saydam",
            claims: claims,
            notBefore: DateTime.Now,
            expires: DateTime.Now.AddDays(1),
            signingCredentials: new SigningCredentials(new SymmetricSecurityKey(Encoding.UTF8.GetBytes("Taner Saydam Taner Saydam Taner Saydam Taner Saydam Taner Saydam Taner Saydam Taner Saydam Taner Saydam Taner Saydam Taner Saydam Taner Saydam Taner Saydam Taner Saydam Taner Saydam ")), SecurityAlgorithms.HmacSha512));
        JwtSecurityTokenHandler handler = new();

        return handler.WriteToken(jwtSecurityToken);
    }
}
