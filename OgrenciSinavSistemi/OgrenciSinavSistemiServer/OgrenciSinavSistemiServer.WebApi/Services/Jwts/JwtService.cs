using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using OgrenciSinavSistemiServer.WebApi.Models.Users;
using OgrenciSinavSistemiServer.WebApi.Options;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace OgrenciSinavSistemiServer.WebApi.Services.Jwts;

public class JwtService(IOptions<Jwt> jwt) : IJwtService
{
    public string CreateToken(User user)
    {
        var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwt.Value.SecretKey));

        List<Claim> claims = new()
        {
            new Claim("UserId", user.Id.ToString())
        };

        JwtSecurityToken jwtSecurity = new(
            issuer: jwt.Value.Issuer,
            audience: jwt.Value.Audience,
            claims: claims,
            notBefore: DateTime.Now,
            expires: DateTime.Now.AddDays(1),
            signingCredentials: new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha512));

        JwtSecurityTokenHandler handler = new();

        string token = handler.WriteToken(jwtSecurity);

        return token;
    }
}
