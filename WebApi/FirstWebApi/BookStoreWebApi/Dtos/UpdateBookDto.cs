using BookStoreWebApi.ValueObjects;

namespace BookStoreWebApi.Dtos;

public sealed record UpdateBookDto(
    string Id,
    string Name,
    Money DailyPrice,
    string Summary,
    string Author,
    DateTime PublishDate,
    int Quantity,
    bool IsActive,
    IFormFile? Image
);