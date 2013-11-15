using System;

namespace Commerce.Core
{
    public interface IValueObject<T> : IEquatable<T>
    {

        bool Equals(object other);
        int GetHashCode();
    }
}
