namespace BookStoreWebApi.ValueObjects;

public sealed record Address(
    string City,
    string Country,
    string Street,
    string ZipCode,
    string OpenAddress);