namespace Domain_DrivenDesign.Domain.Apartments;

public record Currency
{
    internal static readonly Currency None = new("");
    public static readonly Currency EUR = new("EUR");
    public static readonly Currency TRY = new("TRY");
    public static readonly Currency USD = new("USD");

    public string Code { get; init; }

    private Currency(string code)=> Code = code;

    public static Currency FromCode(string code)
    {
        return All.FirstOrDefault(p=> p.Code == code) ?? 
            throw new ArgumentException($"Currency code {code} is not supported.");
    }

    public static readonly IReadOnlyCollection<Currency> All = new[]
    {
        EUR, TRY, USD
    };
}
