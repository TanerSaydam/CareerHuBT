namespace BookStoreWebApi.Dtos;

public sealed record RequestDto(
    int PageNumber = 1,
    int PageSize = 10,
    string Search = "");