using System;
using System.Data;
using System.Linq;
using Commerce.Core.Entities;

namespace Commerce.Core.DataAccess
{
    public interface IRepository
    {
        IQueryable<T> Query<T>();
        T Load<T, TId>(TId id) where T : AggregateRoot<T, TId>;
        T Get<T, TId>(TId id) where T : AggregateRoot<T, TId>;
        void Insert<T, TId>(T entity) where T : AggregateRoot<T, TId>;
        void Delete<T, TId>(T entity) where T : AggregateRoot<T, TId>;
        void SaveOrUpdate<T, TId>(T entity) where T : AggregateRoot<T, TId>;
        void Refresh<T, TId>(T entity) where T : AggregateRoot<T, TId>;
        IDbCommand CreateSqlCommand();
        void ExecuteInTransaction(Action action);
        void Flush();
    }
}
