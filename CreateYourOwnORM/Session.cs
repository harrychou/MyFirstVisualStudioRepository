/*******************************
 * Code adopted from Davy Brion's posts 
 * http://davybrion.com/blog/2009/08/build-your-own-data-access-layer-series/
 * *******************************/

using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace CreateYourOwnORM
{
    public class Session : ISession
    {
        private readonly string connectionString;
        private SqlConnection connection;
        private SqlTransaction transaction;
        private readonly MetaDataStore metaDataStore;
        private readonly EntityHydrater hydrater;
        private readonly SessionLevelCache sessionLevelCache;

        public Session(string connectionString, MetaDataStore metaDataStore)
        {
            this.connectionString = connectionString;
            this.metaDataStore = metaDataStore;
            sessionLevelCache = new SessionLevelCache();
            hydrater = new EntityHydrater(metaDataStore, sessionLevelCache);
        }

        private void InitializeConnection()
        {
            connection = new SqlConnection(connectionString);
            connection.Open();
            transaction = connection.BeginTransaction();
        }

        public SqlConnection GetConnection()
        {
            if (connection == null)
            {
                InitializeConnection();
            }

            return connection;
        }

        public SqlTransaction GetTransaction()
        {
            if (transaction == null)
            {
                InitializeConnection();
            }

            return transaction;
        }

        public IQuery CreateQuery(string sql)
        {
            var command = GetConnection().CreateCommand();
            command.Transaction = GetTransaction();
            command.CommandText = sql;
            return new Query(command, metaDataStore, hydrater);
        }

        public IQuery CreateQuery<TEntity>(string whereClause)
        {
            return CreateQuery(metaDataStore.GetTableInfoFor<TEntity>().GetSelectStatementForAllFields() + " " + whereClause);
        }

        public TableInfo GetTableInfoFor<TEntity>()
        {
            return metaDataStore.GetTableInfoFor<TEntity>();
        }

        public void Commit()
        {
            transaction.Commit();
        }

        public void Rollback()
        {
            transaction.Rollback();
        }

        public void Dispose()
        {
            if (transaction != null) transaction.Dispose();
            if (connection != null) connection.Dispose();
        }

        private TAction CreateAction<TAction>()
            where TAction : DatabaseAction
        {
            return (TAction)Activator.CreateInstance(typeof(TAction), GetConnection(), GetTransaction(),
                                                     metaDataStore, hydrater, sessionLevelCache);
        }

        public TEntity Get<TEntity>(object id)
        {
            return CreateAction<GetByIdAction>().Get<TEntity>(id);
        }

        public IEnumerable<TEntity> FindAll<TEntity>()
        {
            return CreateAction<FindAllAction>().FindAll<TEntity>();
        }

        public TEntity Insert<TEntity>(TEntity entity)
        {
            return CreateAction<InsertAction>().Insert(entity);
        }

        public TEntity Update<TEntity>(TEntity entity)
        {
            return CreateAction<UpdateAction>().Update(entity);
        }

        public void Delete<TEntity>(TEntity entity)
        {
            CreateAction<DeleteAction>().Delete(entity);
        }

        public void InitializeProxy(object proxy, Type targetType)
        {
            CreateAction<InitializeProxyAction>().InitializeProxy(proxy, targetType);
        }

        public void ClearCache()
        {
            sessionLevelCache.ClearAll();
        }

        public void RemoveFromCache(object entity)
        {
            sessionLevelCache.Remove(entity);
        }

        public void RemoveAllInstancesFromCache<TEntity>()
        {
            sessionLevelCache.RemoveAllInstancesOf(typeof(TEntity));
        }
    }
}