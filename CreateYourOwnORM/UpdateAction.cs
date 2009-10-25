/*******************************
 * Code adopted from Davy Brion's posts 
 * http://davybrion.com/blog/2009/08/build-your-own-data-access-layer-series/
 * *******************************/

using System.Data.SqlClient;

namespace CreateYourOwnORM
{
    public class UpdateAction : DatabaseAction
    {
        public UpdateAction(SqlConnection connection, SqlTransaction transaction, MetaDataStore metaDataStore,
                            EntityHydrater hydrater, SessionLevelCache sessionLevelCache)
            : base(connection, transaction, metaDataStore, hydrater, sessionLevelCache)
        {
        }
 
        public TEntity Update<TEntity>(TEntity entity)
        {
            using (var command = CreateCommand())
            {
                var tableInfo = MetaDataStore.GetTableInfoFor<TEntity>();
 
                command.CommandText = tableInfo.GetUpdateStatement();
 
                foreach (var parameterInfo in tableInfo.GetParametersForUpdate(entity))
                {
                    command.CreateAndAddInputParameter(parameterInfo.DbType, parameterInfo.Name, parameterInfo.Value);
                }
 
                command.ExecuteNonQuery();
                return entity;
            }
        }
    }
}