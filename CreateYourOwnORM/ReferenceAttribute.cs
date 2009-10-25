/*******************************
 * Code adopted from Davy Brion's posts 
 * http://davybrion.com/blog/2009/08/build-your-own-data-access-layer-series/
 * *******************************/

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