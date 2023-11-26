namespace BookStoreWebApi.Exceptions;

public class NotFoundBookException : Exception
{
    public NotFoundBookException() : base("Kitap bulunamadı")
    {
    }
}