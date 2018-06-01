using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NAngular.DataAccess.DataMapper
{
    public class ParameterList : List<SqlParameter>
    {
        public ParameterList()
        {

        }

        public void Add(string key, object value)
        {
            base.Add(new SqlParameter() { ParameterName = key, Value = value });
        }
    }
}
