public class Entity
{
    public Guid Id { get; protected set; }
    public override bool Equals(object obj)
    {
        if (obj is not Entity other)
        {
            return false;
        }

        if (ReferenceEquals(this, other))
        {
            return true;
        }

        if (Id.Equals(default) || other.Id.Equals(default))
        {
            return false;
        }

        return Id.Equals(other.Id);
    }

    public static bool operator ==(Entity a, Entity b)
        => a is null && b is null || a is not null && b is not null && a.Equals(b);

    public static bool operator !=(Entity a, Entity b)
        => !(a == b);

    public override int GetHashCode()
        => (GetType().ToString() + Id).GetHashCode(); 
}
