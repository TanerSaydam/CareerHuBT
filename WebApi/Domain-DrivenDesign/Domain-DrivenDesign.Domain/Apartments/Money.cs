namespace Domain_DrivenDesign.Domain.Apartments;
public record Money(decimal Amount, Currency Currency)
{
    public static Money operator +(Money a, Money b)
    {
        if(a.Currency != b.Currency)
        {
            throw new ArgumentException("Cannot add different currencies.");
        }

        return new Money(a.Amount + b.Amount, a.Currency);
    }

    public static Money Zero() => new(0, Currency.None);
}
