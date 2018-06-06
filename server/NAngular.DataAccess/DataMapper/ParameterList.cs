using System.Collections.Generic;
using System.Data.SqlClient;

namespace NAngular.DataAccess.DataMapper
{
    public class ParameterList : List<SqlParameter>
    {
        public void Add(string key, object value)
        {
            base.Add(new SqlParameter {ParameterName = key, Value = value});
        }
    }
}
