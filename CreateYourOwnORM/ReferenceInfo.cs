using System;
using System.Reflection;

namespace CreateYourOwnORM
{
    public class ReferenceInfo : ColumnInfo
    {
        public Type ReferenceType { get; private set; }

        public ReferenceInfo(MetaDataStore store, string name, Type referenceType, PropertyInfo propertyInfo)
            : base(store, name, store.GetTableInfoFor(referenceType).PrimaryKey.DotNetType,
                   store.GetTableInfoFor(referenceType).PrimaryKey.DbType, propertyInfo)
        {
            ReferenceType = referenceType;
        }
    }
}