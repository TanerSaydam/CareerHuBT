namespace LiveSupportServer.Domain.Abstracts;
public abstract class Entity //DDD Entity 
{
    protected Entity(string id)
    {
        Id = id;
    }
    public string Id { get; init; }

    public override bool Equals(object? obj)
    {
        if(obj is not Entity entity)
        {
            return false;
        }

        return entity.Id == Id;   
    }

    public override int GetHashCode()
    {
        return Id.GetHashCode();
    }
}

