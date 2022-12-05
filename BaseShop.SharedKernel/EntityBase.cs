using System.ComponentModel.DataAnnotations.Schema;

namespace BaseShop.SharedKernel;

public abstract class EntityBase<TKey>
{
    public TKey Id { get; protected set; }
    public override bool Equals(object obj)
    {
        var entity = obj as Entity<TKey>;
        return entity != null &&
            GetType() == entity.GetType() &&
            EqualityComparer<TKey>.Default.Equals(Id, entity.Id);
    }

    public static bool operator ==(Entity<TKey> a, Entity<TKey> b)
    {
        if (ReferenceEquals(a, null) && ReferenceEquals(b, null))
            return true;

        if (ReferenceEquals(a, null) || ReferenceEquals(b, null))
            return false;

        return a.Equals(b);
    }

    public static bool operator !=(Entity<TKey> a, Entity<TKey> b)
    {
        return !(a == b);
    }

    public override int GetHashCode()
    {
        return HashCode.Combine(GetType(), Id);
    }
    private List<DomainEventBase> _domainEvents = new();
    [NotMapped]
    public IEnumerable<DomainEventBase> DomainEvents => _domainEvents.AsReadOnly();
    protected void RegisterDomainEvent(DomainEventBase domainEvent) => _domainEvents.Add(domainEvent);
    internal void ClearDomainEvents() => _domainEvents.Clear();


}
