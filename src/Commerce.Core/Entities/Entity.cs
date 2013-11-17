namespace Commerce.Core.Entities
{
    public abstract class Entity<T, TId> : IEntity<T, TId> where T : Entity<T, TId>  
    {

        public TId Id { get; protected set; }

        protected virtual bool MemberwiseEquals(T other)
        {
            // Default to reference equality?
            return false;
        }

        public bool Equals(T other)
        {
            if (ReferenceEquals(this, other)) return true;
            if (ReferenceEquals(null, other)) return false;

            if (Equals(other.Id, Id))
                return !Equals(Id, default(TId)) || MemberwiseEquals(other);

            return false;
        }

        public override bool Equals(object obj)
        {
            return Equals(obj as T);
        }

        public override int GetHashCode()
        {
            return Id.GetHashCode();
        }

    }

    public abstract class Entity<T> : Entity<T, long> where T : Entity<T, long>
    {
    }

}
