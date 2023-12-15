namespace LiveSupportServer.Domain.Shared.ValueObjects;

public sealed record Name
{
    public string Value { get; init; }
    public Name(string value)
    {
        if (value.Length < 5)
        {
            throw new ArgumentException("Ad soyad en az 5 karakter olmalıdır!");
        }

        Value = value;
    }
}