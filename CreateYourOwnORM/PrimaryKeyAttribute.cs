using System;

namespace CreateYourOwnORM
{
    [AttributeUsage(AttributeTargets.Property, Inherited = true)]
    public class PrimaryKeyAttribute : Attribute
    {
        public string ColumnName { get; private set; }

        public PrimaryKeyAttribute(string columnName)
        {
            ColumnName = columnName;
        }
    }
}