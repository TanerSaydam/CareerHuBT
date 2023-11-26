namespace BookStoreWebApi.Dtos;

public sealed record RegisterDto(
    string UserName,
    string Email,
    string NameLastname,
    string Password);