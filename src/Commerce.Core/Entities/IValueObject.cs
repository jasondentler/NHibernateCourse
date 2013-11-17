using System;

namespace Commerce.Core.Entities
{

    public interface IValueObject
    {
    }

    public interface IValueObject<T> : IValueObject, IEquatable<T> where T : IValueObject<T>
    {
        bool Equals(object other);
        int GetHashCode();
    }
}
