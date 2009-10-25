/*******************************
 * Code adopted from Davy Brion's posts 
 * http://davybrion.com/blog/2009/08/build-your-own-data-access-layer-series/
 * *******************************/

using System.Data.SqlClient;

namespace CreateYourOwnORM
{
    public class DeleteAction : DatabaseAction
    {
        public DeleteAction(SqlConnection connection, SqlTransaction transaction, MetaDataStore metaDataStore,
                            EntityHydrater hydrater, SessionLevelCache sessionLevelCache)
            : base(connection, transaction, metaDataStore, hydrater, sessionLevelCache)
        {
        }

        public void Delete<TEntity>(TEntity entity)
        {
            using (var command = CreateCommand())
            {
                var tableInfo = MetaDataStore.GetTableInfoFor<TEntity>();
                command.CommandText = tableInfo.GetDeleteStatement();
                object id = tableInfo.PrimaryKey.PropertyInfo.GetValue(entity, null);
                command.CreateAndAddInputParameter(tableInfo.PrimaryKey.DbType, tableInfo.GetPrimaryKeyParameterName(), id);
                command.ExecuteNonQuery();
                SessionLevelCache.Remove(entity);
            }
        }
    }
}