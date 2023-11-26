using BookStoreWebApi.Models.Abstractions;

namespace BookStoreWebApi.Models;

public sealed class Exception : Entity
{
    public string Message { get; set; }
    public string Path { get; set; }
    public string StackTrace { get; set; }
    public string InnerException { get; set; }
    public DateTime CreatedAt { get; set; }
}