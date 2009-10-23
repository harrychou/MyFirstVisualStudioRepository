using System.Data.SqlClient;

namespace CreateYourOwnORM
{
    public abstract class DatabaseAction
    {
        private readonly SqlConnection connection;
        private readonly SqlTransaction transaction;
        protected MetaDataStore MetaDataStore { get; private set; }
        protected EntityHydrater Hydrater { get; private set; }
        protected SessionLevelCache SessionLevelCache { get; private set; }

        protected DatabaseAction(SqlConnection connection, SqlTransaction transaction, MetaDataStore metaDataStore, 
                                 EntityHydrater hydrater, SessionLevelCache sessionLevelCache)
        {
            this.connection = connection;
            this.transaction = transaction;
            MetaDataStore = metaDataStore;
            Hydrater = hydrater;
            SessionLevelCache = sessionLevelCache;
        }
 
        protected SqlCommand CreateCommand()
        {
            var command = connection.CreateCommand();
            command.Transaction = transaction;
            return command;
        }
    }
}