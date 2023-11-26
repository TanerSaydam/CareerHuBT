using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace BookStoreWebApi.Options;

public sealed class JwtOptionsSetup : IPostConfigureOptions<JwtBearerOptions>
{
    private readonly Jwt _jwt;

    public JwtOptionsSetup(IOptions<Jwt> jwt)
    {
        _jwt = jwt.Value;
    }

    public void PostConfigure(string name, JwtBearerOptions options)
    {
        options.TokenValidationParameters.ValidateIssuer = true;
        options.TokenValidationParameters.ValidateAudience = true;
        options.TokenValidationParameters.ValidateLifetime = true;
        options.TokenValidationParameters.ValidIssuer = _jwt.Issuer;
        options.TokenValidationParameters.ValidAudience = _jwt.Audience;
        options.TokenValidationParameters.IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwt.SecretKey));
    }
}