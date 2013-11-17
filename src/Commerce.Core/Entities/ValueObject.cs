using System.Collections.Generic;
using System.Linq;

namespace Commerce.Core.Entities
{

    // Why is this a bad idea?
    public abstract class ValueObject<T> : IValueObject<T> where T : class, IValueObject<T>
    {
        protected abstract IEnumerable<object> HashCodeMembers();
        protected abstract bool MembersEquals(T other);
        
        public bool Equals(T other)
        {
            if (ReferenceEquals(this, other)) return true;
            if (ReferenceEquals(null, other)) return false;

            return MembersEquals(other);
        }

        public override bool Equals(object obj)
        {
            return Equals(obj as T);
        }

        public override int GetHashCode()
        {
            return HashCodeMembers()
                .Select(x => ReferenceEquals(x, null) ? 0 : x.GetHashCode())
                .Aggregate(0, (hash, next) => unchecked((hash*397) ^ next));
        }
    }
}