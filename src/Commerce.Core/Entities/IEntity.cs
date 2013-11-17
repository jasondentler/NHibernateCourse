using System;

namespace Commerce.Core.Entities
{
    public interface IEntity
    {
    }

    public interface IEntity<T, TId> : IEntity, IEquatable<T> where T : IEntity<T, TId>
    {
        bool Equals(object other);
        int GetHashCode();
    }

}