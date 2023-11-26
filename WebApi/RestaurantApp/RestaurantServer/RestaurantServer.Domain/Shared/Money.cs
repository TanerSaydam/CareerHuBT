using System.ComponentModel.DataAnnotations.Schema;

namespace RestaurantServer.Domain.Shared;
public sealed record Money
{
    public Money(decimal value)
    {
        if(value < 0)
        {
            throw new ArgumentException("Fiyat 0 dan küçük olamaz");
        }

        Value = value;
    }
    public decimal Value { get; init; }
}
