using BookStoreWebApi.Context;
using BookStoreWebApi.Models;
using BookStoreWebApi.Options;
using BookStoreWebApi.Utilities;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace BookStoreWebApi.Authentication;

public static class JwtProvider
{
    public static TokenResponse CreateToken(AppUser user)
    {
        var claims = new Claim[]
        {
            new Claim(JwtRegisteredClaimNames.Sub, user.Id),
            new Claim(JwtRegisteredClaimNames.Email, user.Email),
            new Claim(JwtRegisteredClaimNames.Name, user.NameLastname)
        };

        var expires = DateTime.Now.AddMinutes(10);

        var jwt = ServiceTool.ServiceProvider.GetRequiredService<IOptions<Jwt>>().Value;

        JwtSecurityToken jwtSecurityToken = new(
            issuer: jwt.Issuer,
            audience: jwt.Audience,
            claims: claims,
            notBefore: DateTime.Now,
            expires: expires,
            signingCredentials: new SigningCredentials(new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwt.SecretKey)), SecurityAlgorithms.HmacSha512));

        var handler = new JwtSecurityTokenHandler();
        var token = handler.WriteToken(jwtSecurityToken);

        var refreshToken = Guid.NewGuid().ToString();
        var refreshTokenExpires = expires.AddMinutes(20);

        user.RefreshToken = refreshToken;
        user.RefreshTokenExpires = refreshTokenExpires;
        var context = ServiceTool.ServiceProvider.GetRequiredService<AppDbContext>();
        context.Set<AppUser>().Update(user);
        context.SaveChanges();

        return new(token, refreshToken, refreshTokenExpires);
    }
}

public sealed record TokenResponse(
    string Token,
    string RefreshToken,
    DateTime RefreshTokenExpires);