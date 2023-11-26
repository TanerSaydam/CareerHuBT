namespace BookStoreWebApi.Exceptions;

public sealed class PasswordIsWrongException : Exception
{
    public PasswordIsWrongException() : base("Şifre yanlış")
    {
    }
}