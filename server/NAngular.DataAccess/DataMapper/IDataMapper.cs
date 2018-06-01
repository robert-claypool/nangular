using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NAngular.DataAccess.DataMapper
{
    public interface IDataMapper
    {
        int ExecuteStoredProcedureNonQuery(string spName, ParameterList inputParameters = null);

        List<T> ExecuteStoredProcedureReader<T>(string spName, ParameterList inputParameters = null);
        
        object ExecuteStoredProcedureScalar(string spName, ParameterList inputParameters = null);
    }
}
