using Microsoft.Extensions.Options;
using System.ComponentModel.DataAnnotations;

namespace BookStoreWebApi.Options;

public class JwtOptions : IConfigureOptions<Jwt> //options pattern
{
    private readonly IConfiguration _configuration;

    public JwtOptions(IConfiguration configuration)
    {
        _configuration = configuration;
    }

    public void Configure(Jwt options)
    {
        _configuration.GetSection("Jwt").Bind(options);
    }
}

public sealed class Jwt
{
    [Required]
    public string Issuer { get; set; }

    [Required]
    public string Audience { get; set; }

    [Required]
    public string SecretKey { get; set; }
}