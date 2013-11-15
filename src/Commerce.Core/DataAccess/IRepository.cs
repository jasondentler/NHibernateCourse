using System;
using System.Data;
using System.Linq;

namespace Commerce.Core.DataAccess
{
    public interface IRepository
    {
        IQueryable<T> Query<T>();
        T Load<T, TId>(TId id);
        T Get<T, TId>(TId id);
        void Insert<T>(T entity);
        void Delete<T>(T entity);
        void SaveOrUpdate<T>(T entity);
        void Refresh<T>(T entity);
        IDbCommand CreateSqlCommand();
        void ExecuteInTransaction(Action action);
        void Flush();
    }
}
