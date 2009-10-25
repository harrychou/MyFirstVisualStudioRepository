/*******************************
 * Code adopted from Davy Brion's posts 
 * http://davybrion.com/blog/2009/08/build-your-own-data-access-layer-series/
 * *******************************/

using System.Data;

namespace CreateYourOwnORM
{
    public class AdoParameterInfo
    {
        public DbType DbType { get; private set; }
        public string Name { get; private set; }
        public object Value { get; private set; }

        public AdoParameterInfo(string name, DbType dbType, object value)
        {
            Name = name;
            DbType = dbType;
            Value = value;
        }
    }
}