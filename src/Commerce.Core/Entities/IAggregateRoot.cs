namespace Commerce.Core.Entities
{
    public interface IAggregateRoot
    {
    }

    public interface IAggregateRoot<T, TId> : IAggregateRoot, IEntity<T, TId> where T : IAggregateRoot<T, TId>
    {
    }

}