namespace LiveSupportServer.Domain.ChatRooms;

public sealed record Subject
{
    public string Value { get; init; }
    public Subject(string value)
    {
        if (value.Length < 5)
        {
            throw new ArgumentException("Mesaj 5 karakterden küçük olamaz!");
        }
        Value = value;
    }
}