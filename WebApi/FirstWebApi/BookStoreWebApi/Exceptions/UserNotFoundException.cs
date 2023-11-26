namespace BookStoreWebApi.Exceptions;

public sealed class UserNotFoundException : Exception
{
    public UserNotFoundException() : base("Kullanıcı bulunamadı")
    {
    }
}