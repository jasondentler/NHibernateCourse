namespace Commerce.Core.Extensions
{
    public static class ObjectExtensions
    {

        public static int GetHashCodeSafely(this object o)
        {
            if (o == null)
                return 0;
            return o.GetHashCode();
        }

    }
}
