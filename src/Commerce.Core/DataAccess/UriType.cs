using System;
using System.Data;
using NHibernate;
using NHibernate.SqlTypes;
using NHibernate.UserTypes;

namespace Commerce.Core.DataAccess
{
    public class UriType : IUserType
    {
        public SqlType[] SqlTypes
        {
            get
            {
                //We store our Uri in a single column in the database that can contain a string
                var types = new SqlType[1];
                types[0] = new SqlType(DbType.String);
                return types;
            }
        }

        public Type ReturnedType
        {
            get { return typeof(Uri); }
        }

        public new bool Equals(object x, object y)
        {
            //Uri implements Equals it self by comparing the Uri's based 
            // on value so we use this implementation
            if (x == null)
            {
                return false;
            }
            return x.Equals(y);
        }

        public int GetHashCode(object x)
        {
            //Again URL itself implements GetHashCode so we use that
            return x.GetHashCode();
        }

        public object NullSafeGet(IDataReader rs, string[] names, object owner)
        {
            //We get the string from the database using the NullSafeGet used to get strings 
            var uriString = (string)NHibernateUtil.String.NullSafeGet(rs, names[0]);

            //And save it in the Uri object. This would be the place to make sure that your string 
            //is valid for use with the System.Uri class, but i will leave that to you
            var result = new Uri(uriString);
            return result;
        }

        public void NullSafeSet(IDbCommand cmd, object value, int index)
        {
            //Set the value using the NullSafeSet implementation for string from NHibernateUtil
            if (value == null)
            {
                NHibernateUtil.String.NullSafeSet(cmd, null, index);
                return;
            }
            value = value.ToString(); //ToString called on Uri instance
            NHibernateUtil.String.NullSafeSet(cmd, value, index);
        }

        public object DeepCopy(object value)
        {
            //We deep copy the uri by creating a new instance with the same contents
            if (value == null) return null;
            return new Uri(value.ToString());
        }

        public bool IsMutable
        {
            get { return false; }
        }

        public object Replace(object original, object target, object owner)
        {
            //As our object is immutable we can just return the original
            return original;
        }

        public object Assemble(object cached, object owner)
        {
            //Used for caching, as our object is immutable we can just return it as is
            return cached;
        }

        public object Disassemble(object value)
        {
            //Used for caching, as our object is immutable we can just return it as is
            return value;
        }
    }

}
