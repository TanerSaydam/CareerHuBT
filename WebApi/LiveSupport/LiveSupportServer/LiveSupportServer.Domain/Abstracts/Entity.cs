namespace LiveSupportServer.Domain.Abstracts;
public abstract class Entity //DDD Entity 
{
    public Entity(string id)
    {
        Id = id;
    }
    public string Id { get; init; }

    public override bool Equals(object? obj)
    {
        if(obj is null || obj is not Entity entity)
        {
            return false;
        }

        return ((Entity)obj).Id == Id;   
    }

    public override int GetHashCode()
    {
        return Id.GetHashCode();
    }
}

