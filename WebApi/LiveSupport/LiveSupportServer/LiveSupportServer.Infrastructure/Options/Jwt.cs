namespace LiveSupportServer.Infrastructure.Options;
public sealed class Jwt
{
    public string Issuer { get; set; }
    public string Audience { get; set; }
    public string SecretKey { get; set; }
}
