namespace BookStoreWebApi.ValueObjects;

public sealed record Money(
    decimal Amount,
    string Currency);