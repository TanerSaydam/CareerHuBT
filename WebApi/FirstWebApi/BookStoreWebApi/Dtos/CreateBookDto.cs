using BookStoreWebApi.ValueObjects;

namespace BookStoreWebApi.Dtos;

public sealed record CreateBookDto(
    string Name,
    Money DailyPrice,
    string Summary,
    string Author,
    DateTime PublishDate,
    IFormFile Image,
    int Quantity
);