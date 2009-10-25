/*******************************
 * Code adopted from Davy Brion's posts 
 * http://davybrion.com/blog/2009/08/build-your-own-data-access-layer-series/
 * *******************************/

using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace CreateYourOwnORM
{
    public interface ISession : IDisposable
    {

        void Commit();

        void Rollback();



        IQuery CreateQuery(string sql);

        IQuery CreateQuery<TEntity>(string whereClause);



        TEntity Get<TEntity>(object id);

        IEnumerable<TEntity> FindAll<TEntity>();



        TEntity Insert<TEntity>(TEntity entity);

        TEntity Update<TEntity>(TEntity entity);

        void Delete<TEntity>(TEntity entity);



        TableInfo GetTableInfoFor<TEntity>();



        void ClearCache();

        void RemoveFromCache(object entity);

        void RemoveAllInstancesFromCache<TEntity>();



        SqlConnection GetConnection();

        SqlTransaction GetTransaction();

    }
}