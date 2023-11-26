using Domain_DrivenDesign.Domain.Apartments;

namespace Domain_DrivenDesign.Domain.Abstractions;
public abstract class Entity //DDD Entity yapısında advanced konulardan biri
{
    public Guid Id { get; init; }
    public Entity(Guid id)
    {
        Id = id;
    }

    public override bool Equals(object? obj)
    {
        if(obj is null || obj is not Entity)
        {
            return false;
        }

        return ((Entity)obj).Id == Id;
    }

    public override int GetHashCode()
    {
        return Id.GetHashCode();
    }
   

    public static bool operator ==(Entity? a, Entity? b)
    {
        if(a is null && b is null)
        {
            return false;
        }

        if(a is null || b is null)
        {
            return false;
        }

        return a.Equals(b);
    }

    public static bool operator !=(Entity? a, Entity? b)
    {
        return !(a == b);
    }
}

public class Test
{
    HashSet<int> strings = new() { 1,2,3,1};
    List<int> strings2 = new() { 1,2,3,1,2,3};
    Guid id = Guid.NewGuid();
    public Test()
    {
        Apartment1.Id = id;
        Apartment2.Id = id;
    }
    public Apartment Apartment1 = new();
    public Apartment Apartment2 = new();
}
