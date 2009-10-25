/*******************************
 * Code adopted from Davy Brion's posts 
 * http://davybrion.com/blog/2009/08/build-your-own-data-access-layer-series/
 * *******************************/

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