using System;
using System.Data;
using System.Linq;
using Commerce.Core.Entities;
using NHibernate;
using NHibernate.Linq;

namespace Commerce.Core.DataAccess
{
    public class Repository : IRepository, IDisposable
    {

        private readonly ISessionFactory _sessionFactory;
        private readonly ISession _session;
        private bool _needsFlush = false;

        public Repository(ISessionFactory sessionFactory)
        {
            if (sessionFactory == null) throw new ArgumentNullException("sessionFactory");
            _sessionFactory = sessionFactory;
            _session = sessionFactory.OpenSession();
        }

        public IQueryable<T> Query<T>()
        {
            return _session.Query<T>();
        }

        public T Load<T, TId>(TId id) where T : AggregateRoot<T, TId>
        {
            return _session.Load<T>(id);
        }

        public T Get<T, TId>(TId id) where T : AggregateRoot<T, TId>
        {
            return _session.Get<T>(id);
        }

        private void PerformFlushableActionTransactionally(Action action)
        {
            var didNeedFlush = _needsFlush;
            var shouldIManageTheTransaction = _session.Transaction == null;

            var transaction = _session.Transaction;
            if (shouldIManageTheTransaction)
                transaction = _session.BeginTransaction();

            try
            {
                action();
                _needsFlush = true;
                if (shouldIManageTheTransaction)
                    transaction.Commit();
            }
            catch
            {
                _needsFlush = didNeedFlush;
                if (shouldIManageTheTransaction)
                    transaction.Rollback();
                throw;
            }
        }

        public void Insert<T, TId>(T entity) where T : AggregateRoot<T, TId>
        {
            PerformFlushableActionTransactionally(() => _session.Save(entity));
        }

        public void Delete<T, TId>(T entity) where T : AggregateRoot<T, TId>
        {
            PerformFlushableActionTransactionally(() => _session.Delete(entity));
        }

        public void SaveOrUpdate<T, TId>(T entity) where T : AggregateRoot<T, TId>
        {
            PerformFlushableActionTransactionally(() => _session.SaveOrUpdate(entity));
        }

        public void Refresh<T, TId>(T entity) where T : AggregateRoot<T, TId>
        {
            _session.Refresh(entity);
            _needsFlush = true;
        }

        public IDbCommand CreateSqlCommand()
        {
            Flush();

            var command = _session.Connection.CreateCommand();

            if (_session.Transaction != null && _session.Transaction.IsActive)
                _session.Transaction.Enlist(command);

            return command;
        }

        public void ExecuteInTransaction(Action action)
        {
            Flush();

            PerformFlushableActionTransactionally(action);
        }

        public void Flush()
        {
            if (_needsFlush)
                _session.Flush();
            _needsFlush = false;
        }

        public void Dispose()
        {
            Flush();
            _session.Dispose();
        }
    }
}