using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text.RegularExpressions;
using Microsoft.Practices.EnterpriseLibrary.Data;

namespace NAngular.DataAccess.DataMapper
{
    public class DataMapper : IDataMapper
    {
        #region Global Varaibles

        private readonly List<Database> _appPool = new List<Database>();

        #endregion

        #region Private Methods

        private Database GetDataContext(string connectionString = null)
        {
            Database db;

            if (_appPool.Count == 0)
            {
                var factory = new DatabaseProviderFactory();
                db = factory.CreateDefault();
                _appPool.Add(db);
                return db;
            }

            db = string.IsNullOrEmpty(connectionString)
                ? _appPool.FirstOrDefault()
                : _appPool.FirstOrDefault(d => d.ConnectionString.Equals(connectionString));

            if (db == null)
            {
                var factory = new DatabaseProviderFactory();
                db = factory.Create(connectionString);
                _appPool.Add(db);
            }

            return db;
        }


        private void SetCommandForSP(SqlCommand command, string spName, ParameterList inputParameters,
            SqlConnection dbConnection)
        {
            command.Connection = dbConnection;
            command.CommandType = CommandType.StoredProcedure;
            command.CommandText = spName;
            if (inputParameters != null && inputParameters.Count > 0)
                command.Parameters.AddRange(inputParameters.ToArray());
        }

        private List<T> DataReaderMapToList<T>(IDataReader dr)
        {
            var list = new List<T>();
            while (dr.Read())
            {
                var obj = Activator.CreateInstance<T>();

                var objType = obj.GetType();

                for (var fields = 0; fields < dr.FieldCount; fields++)
                {
                    var name = dr.GetName(fields);

                    var prop = objType.GetProperty(name);

                    if (prop?.GetSetMethod() != null)
                        if (name == prop.Name)
                        {
                            var value = dr.GetValue(fields);
                            if (value != DBNull.Value)
                            {
                                if (!prop.PropertyType.ToString().Contains("Nullable"))
                                    try
                                    {
                                        prop.SetValue(obj, Convert.ChangeType(value, prop.PropertyType), null);
                                    }
                                    catch (InvalidCastException)
                                    {
                                        var strValue = value.ToString();
                                        try
                                        {
                                            prop.SetValue(obj, Enum.Parse(prop.PropertyType, strValue), null);
                                        }
                                        catch (ArgumentException ae)
                                        {
                                            // Check for GUIDs
                                            var regex = new Regex(
                                                "^[0-9A-F]{8}-[0-9A-F]{4}-[0-9A-F]{4}-[0-9A-F]{4}-[0-9A-F]{12}$",
                                                RegexOptions.IgnoreCase);
                                            if (regex.IsMatch(strValue))
                                                prop.SetValue(obj, new Guid(strValue), null);
                                            else
                                                throw new ApplicationException(
                                                    $"Couldn't convert value = {strValue} of type = {value.GetType()}",
                                                    ae);
                                        }
                                    }
                                else
                                    prop.SetValue(obj,
                                        Convert.ChangeType(value,
                                            Nullable.GetUnderlyingType(prop.PropertyType) ??
                                            throw new InvalidOperationException()), null);
                            }
                        }
                }

                list.Add(obj);
            }

            return list;
        }

        private int _ExecuteStoredProcedureNonQuery(string spName, ParameterList inputParameters = null)
        {
            var noOfRowsAffected = 0;

            var dbContext = GetDataContext();
            using (var dbConnection = dbContext.CreateConnection() as SqlConnection)
            {
                if (dbConnection != null)
                {
                    dbConnection.Open();
                    using (var command = new SqlCommand())
                    {
                        SetCommandForSP(command, spName, inputParameters, dbConnection);
                        noOfRowsAffected = dbContext.ExecuteNonQuery(command);

                        dbConnection.Close();
                        command.Dispose();
                    }

                    dbConnection.Dispose();
                }
            }

            return noOfRowsAffected;
        }

        private List<T> _ExecuteStoredProcedureReader<T>(string spName, ParameterList inputParameters = null)
        {
            List<T> resultList = null;

            var dbContext = GetDataContext();
            using (var dbConnection = dbContext.CreateConnection() as SqlConnection)
            {
                if (dbConnection != null)
                {
                    dbConnection.Open();
                    using (var command = new SqlCommand())
                    {
                        SetCommandForSP(command, spName, inputParameters, dbConnection);
                        using (var reader = dbContext.ExecuteReader(command))
                        {
                            resultList = DataReaderMapToList<T>(reader);
                            reader.Close();
                        }


                        dbConnection.Close();
                        command.Dispose();
                    }

                    dbConnection.Dispose();
                }
            }

            return resultList;
        }

        private object _ExecuteStoredProcedureScalar(string spName, ParameterList inputParameters = null)
        {
            object scaler = null;
            var dbContext = GetDataContext();
            using (var dbConnection = dbContext.CreateConnection() as SqlConnection)
            {
                if (dbConnection != null)
                {
                    dbConnection.Open();
                    using (var command = new SqlCommand())
                    {
                        SetCommandForSP(command, spName, inputParameters, dbConnection);
                        scaler = dbContext.ExecuteScalar(command);

                        dbConnection.Close();
                        command.Dispose();
                    }

                    dbConnection.Dispose();
                }
            }

            return scaler;
        }

        #endregion

        #region Public Methods

        public int ExecuteStoredProcedureNonQuery(string spName, ParameterList inputParameters = null)
        {
            return _ExecuteStoredProcedureNonQuery(spName, inputParameters);
        }

        public List<T> ExecuteStoredProcedureReader<T>(string spName, ParameterList inputParameters = null)
        {
            return _ExecuteStoredProcedureReader<T>(spName, inputParameters);
        }

        public object ExecuteStoredProcedureScalar(string spName, ParameterList inputParameters = null)
        {
            return _ExecuteStoredProcedureScalar(spName, inputParameters);
        }

        #endregion
    }
}
