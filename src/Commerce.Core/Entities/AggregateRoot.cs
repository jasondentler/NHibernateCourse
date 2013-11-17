namespace Commerce.Core.Entities
{
    public abstract class AggregateRoot<T, TId> : Entity<T, TId> where T : Entity<T, TId> 
    {
    }

    public abstract class AggregateRoot<T> : AggregateRoot<T, long> where T : Entity<T, long>
    {
    }
}