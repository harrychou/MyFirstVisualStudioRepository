/*******************************
 * Code adopted from Davy Brion's posts 
 * http://davybrion.com/blog/2009/08/build-your-own-data-access-layer-series/
 * *******************************/

using System.Collections.Generic;
using System.Data.SqlClient;

namespace CreateYourOwnORM
{
    public class FindAllAction : DatabaseAction
    {
        public FindAllAction(SqlConnection connection, SqlTransaction transaction, MetaDataStore metaDataStore,
                             EntityHydrater hydrater, SessionLevelCache sessionLevelCache)
            : base(connection, transaction, metaDataStore, hydrater, sessionLevelCache)
        {
        }
 
        public IEnumerable<TEntity> FindAll<TEntity>()
        {
            using (var command = CreateCommand())
            {
                command.CommandText = MetaDataStore.GetTableInfoFor<TEntity>().GetSelectStatementForAllFields().ToString();
                return Hydrater.HydrateEntities<TEntity>(command);
            }
        }
    }
}