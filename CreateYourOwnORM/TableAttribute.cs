/*******************************
 * Code adopted from Davy Brion's posts 
 * http://davybrion.com/blog/2009/08/build-your-own-data-access-layer-series/
 * *******************************/

using System;

namespace CreateYourOwnORM
{
    [AttributeUsage(AttributeTargets.Class, Inherited = true)]
    public class TableAttribute : Attribute
    {
        public string TableName { get; private set; }

        public TableAttribute(string tableName)
        {
            TableName = tableName;
        }

    }
}