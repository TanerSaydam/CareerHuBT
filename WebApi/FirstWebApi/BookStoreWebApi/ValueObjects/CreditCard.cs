namespace BookStoreWebApi.ValueObjects;

public sealed record CreditCard(
    string CardNumber,
    string CardHolderName,
    string ExpirationDate,
    string Cvv);