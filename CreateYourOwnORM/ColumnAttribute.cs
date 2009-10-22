using System;

namespace CreateYourOwnORM
{
    [AttributeUsage(AttributeTargets.Property, Inherited = true)]
    public class ColumnAttribute : Attribute
    {
        public string ColumnName { get; private set; }

        public ColumnAttribute(string columnName)
        {
            ColumnName = columnName;
        }
    }
}