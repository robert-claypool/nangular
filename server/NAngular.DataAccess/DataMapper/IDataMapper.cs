using System.Collections.Generic;

namespace NAngular.DataAccess.DataMapper
{
    public interface IDataMapper
    {
        int ExecuteStoredProcedureNonQuery(string spName, ParameterList inputParameters = null);

        List<T> ExecuteStoredProcedureReader<T>(string spName, ParameterList inputParameters = null);

        object ExecuteStoredProcedureScalar(string spName, ParameterList inputParameters = null);
    }
}
