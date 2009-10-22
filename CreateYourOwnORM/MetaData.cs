namespace CreateYourOwnORM
{
    public abstract class MetaData
    {
        protected MetaDataStore MetaDataStore { get; private set; }

        protected MetaData(MetaDataStore metaDataStore)
        {
            MetaDataStore = metaDataStore;
        }
    }
}