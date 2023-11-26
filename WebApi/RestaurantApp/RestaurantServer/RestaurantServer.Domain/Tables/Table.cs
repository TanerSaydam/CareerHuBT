using RestaurantServer.Domain.Abstractions;
using RestaurantServer.Domain.Shared;

namespace RestaurantServer.Domain.Tables;
public sealed class Table : Entity
{
    private Table() : base(Guid.NewGuid())
    {
        Amount = new(0);
    }
    public Table(int number) : base(Guid.NewGuid())
    {        
        Number = number;
        IsAvailable = true;
        Amount = new(0);
    }

    public int Number { get; private set; }
    public bool IsAvailable { get; private set; }
    public Money Amount { get; private set; }

    public void ChangeStatus()
    {
        IsAvailable = !IsAvailable;
    }

    public void ChangeAmount(decimal amount)
    {
        Amount = new(amount + Amount.Value);
    }
}
