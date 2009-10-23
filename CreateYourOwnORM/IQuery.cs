using System.Collections.Generic;
using System.Data;

namespace CreateYourOwnORM
{
    public interface IQuery
    {

        void AddParameter(string name, object value, DbType dbType);

        TResult GetSingleResult<TResult>();

        IEnumerable<TResult> GetResults<TResult>();

        int ExecuteNonQuery();

    }
}