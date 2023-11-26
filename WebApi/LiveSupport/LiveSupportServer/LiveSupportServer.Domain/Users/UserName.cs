namespace LiveSupportServer.Domain.Users;

public sealed record UserName //Value Object - strong type
{
    public string Value { get; init; }
    public UserName(string value)
    {
        if (value.Length < 3)
        {
            throw new Exception("Kullanıcı adı 3 karakterden küçük olamaz!");
        }

        Value = value;
    }
};

//20:40 başlıyoruz.