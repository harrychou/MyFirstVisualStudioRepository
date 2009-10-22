using System;

namespace CreateYourOwnORM
{
    [AttributeUsage(AttributeTargets.Property, Inherited = true)]
    public class ReferenceAttribute : Attribute
    {
        public string ColumnName { get; private set; }

        public ReferenceAttribute(string columnName)
        {
            ColumnName = columnName;
        }
    }
}