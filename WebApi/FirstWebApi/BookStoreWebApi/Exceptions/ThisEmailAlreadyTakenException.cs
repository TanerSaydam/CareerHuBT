namespace BookStoreWebApi.Exceptions;

public sealed class ThisEmailAlreadyTakenException : Exception
{
    public ThisEmailAlreadyTakenException() : base("Bu email adresi zaten kullanımda")
    {
    }
}