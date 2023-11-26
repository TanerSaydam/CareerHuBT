using LiveSupportServer.Application.Abstractions;
using LiveSupportServer.Domain.Users;
using LiveSupportServer.Infrastructure.Options;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace LiveSupportServer.Infrastructure.Authentication;
internal sealed class JwtProvider : IJwtProvider
{
    private readonly Jwt _jwt;

    public JwtProvider(IOptions<Jwt> jwt)
    {
        _jwt = jwt.Value;
    }

    public string CreateToken(User user)
    {
        Claim[] claims = new Claim[]
        {
            new Claim("Name", user.Name.Value),
            new Claim("UserId", user.Id)
        };

        DateTime expires = DateTime.Now.AddDays(1);

        JwtSecurityToken jwtSecurityToken = new(
            issuer: _jwt.Issuer,
            audience: _jwt.Audience,
            claims: claims,
            notBefore: DateTime.Now,
            expires: expires,
            signingCredentials: new SigningCredentials(new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwt.SecretKey)),SecurityAlgorithms.HmacSha512));

        JwtSecurityTokenHandler handler = new();
        string token = handler.WriteToken(jwtSecurityToken);
        return token;
    }
}
