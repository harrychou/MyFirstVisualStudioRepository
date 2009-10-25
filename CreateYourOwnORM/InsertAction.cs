/*******************************
 * Code adopted from Davy Brion's posts 
 * http://davybrion.com/blog/2009/08/build-your-own-data-access-layer-series/
 * *******************************/

using System;
using System.Data.SqlClient;

namespace CreateYourOwnORM
{
    public class InsertAction : DatabaseAction
    {
        public InsertAction(SqlConnection connection, SqlTransaction transaction, MetaDataStore metaDataStore,
                            EntityHydrater hydrater, SessionLevelCache sessionLevelCache)
            : base(connection, transaction, metaDataStore, hydrater, sessionLevelCache)
        {
        }
 
        public TEntity Insert<TEntity>(TEntity entity)
        {
            using (var command = CreateCommand())
            {
                var tableInfo = MetaDataStore.GetTableInfoFor<TEntity>();
 
                command.CommandText = tableInfo.GetInsertStatement();
 
                foreach (var parameterInfo in tableInfo.GetParametersForInsert(entity))
                {
                    command.CreateAndAddInputParameter(parameterInfo.DbType, parameterInfo.Name, parameterInfo.Value);
                }
 
                object id = Convert.ChangeType(command.ExecuteScalar(), tableInfo.PrimaryKey.DotNetType);
                tableInfo.PrimaryKey.PropertyInfo.SetValue(entity, id, null);
                SessionLevelCache.Store(typeof(TEntity), id, entity);
                return entity;
            }
        }
    }
}