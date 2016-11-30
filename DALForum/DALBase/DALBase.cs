using Common;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DALForum
{
    public abstract class DALBase
    {
        private static readonly string DATASOURCE = Properties.Settings.Default.datasource;
        private static readonly string DATABASE = Properties.Settings.Default.database;
        private static readonly string USERID = Properties.Settings.Default.userid;
        private static readonly string PWD = Properties.Settings.Default.pwd;
        private static StringBuilder CNXSTR = null;

        private static string CreateCnxStr()
        {
            CNXSTR = new StringBuilder();
            CNXSTR.Append("Data source = ");
            CNXSTR.Append(DATASOURCE);
            CNXSTR.Append(";");
            CNXSTR.Append("Initial Catalog = ");
            CNXSTR.Append(DATABASE);
            CNXSTR.Append(";");
            CNXSTR.Append("User ID = ");
            CNXSTR.Append(USERID);
            CNXSTR.Append(";");
            CNXSTR.Append("Password = ");
            CNXSTR.Append(PWD);
            CNXSTR.Append(";");
            return CNXSTR.ToString();
        }
        // ConnectionString
        protected static string ConnectionString
        {
            get { return CreateCnxStr(); }
        }

        // GetDbSqlCommand
        protected static SqlCommand GetDbSQLCommand(string sqlQuery)
        {
            SqlCommand command = new SqlCommand();
            command.Connection = GetDbConnection();
            command.CommandType = CommandType.Text;
            command.CommandText = sqlQuery;
            return command;
        }

        // GetDbConnection
        protected static SqlConnection GetDbConnection()
        {
            return new SqlConnection(ConnectionString);
        }

        // GetDbSprocCommand
        protected static SqlCommand GetDbSprocCommand(string sprocName)
        {
            SqlCommand command = new SqlCommand(sprocName);
            command.Connection = GetDbConnection();
            command.CommandType = CommandType.StoredProcedure;
            return command;
        }

        // CreateNullParameter
        protected static SqlParameter CreateNullParameter(string name, SqlDbType paramType)
        {
            SqlParameter parameter = new SqlParameter();
            parameter.SqlDbType = paramType;
            parameter.ParameterName = name;
            parameter.Value = null;
            parameter.Direction = ParameterDirection.Input;
            return parameter;
        }

        // CreateNullParameter - avec la taille pour nvarchars
        protected static SqlParameter CreateNullParameter(string name, SqlDbType paramType, int size)
        {
            SqlParameter parameter = new SqlParameter();
            parameter.SqlDbType = paramType;
            parameter.ParameterName = name;
            parameter.Size = size;
            parameter.Value = null;
            parameter.Direction = ParameterDirection.Input;
            return parameter;
        }

        // CreateOutputParameter
        protected static SqlParameter CreateOutputParameter(string name, SqlDbType paramType)
        {
            SqlParameter parameter = new SqlParameter();
            parameter.SqlDbType = paramType;
            parameter.ParameterName = name;
            parameter.Direction = ParameterDirection.Output;
            return parameter;
        }

        // CreateOuputParameter - avec la taille pour nvarchars
        protected static SqlParameter CreateOutputParameter(string name, SqlDbType paramType, int size)
        {
            SqlParameter parameter = new SqlParameter();
            parameter.SqlDbType = paramType;
            parameter.Size = size;
            parameter.ParameterName = name;
            parameter.Direction = ParameterDirection.Output;
            return parameter;
        }
        
        // CreateParameter - int
        protected static SqlParameter CreateParameter(string name, int value)
        {
            if (value == Common.DTOBase.Int_NullValue)
            {
                // Si la valeur est null alors crée un paramètre null.
                return CreateNullParameter(name, SqlDbType.Int);
            }
            else
            {
                SqlParameter parameter = new SqlParameter();
                parameter.SqlDbType = SqlDbType.Int;
                parameter.ParameterName = name;
                parameter.Value = value;
                parameter.Direction = ParameterDirection.Input;
                return parameter;
            }
        }

        // CreateParameter - datetime
        protected static SqlParameter CreateParameter(string name, DateTime value)
        {
            if (value == Common.DTOBase.DateTime_NullValue)
            {
                // Si la valeur est null alors crée un paramètre null.
                return CreateNullParameter(name, SqlDbType.DateTime);
            }
            else
            {
                SqlParameter parameter = new SqlParameter();
                parameter.SqlDbType = SqlDbType.DateTime;
                parameter.ParameterName = name;
                parameter.Value = value;
                parameter.Direction = ParameterDirection.Input;
                return parameter;
            }
        }

        // CreateParameter - nvarchar
        protected static SqlParameter CreateParameter(string name, string value, int size)
        {
            if (value == Common.DTOBase.String_NullValue)
            {
                // Si la valeur est null alors crée un paramètre null.
                return CreateNullParameter(name, SqlDbType.NVarChar);
            }
            else
            {
                SqlParameter parameter = new SqlParameter();
                parameter.SqlDbType = SqlDbType.NVarChar;
                parameter.Size = size;
                parameter.ParameterName = name;
                parameter.Value = value;
                parameter.Direction = ParameterDirection.Input;
                return parameter;
            }
        }

        // GetSingleDTO
        protected static T GetSingleDTO<T>(ref SqlCommand command) where T : DTOBase
        {
            T dto = null;
            try
            {
                command.Connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                if (reader.HasRows)
                {
                    reader.Read();
                    DTOParser parser = DTOParserFactory.GetParser(typeof(T));
                    parser.PopulateOrdinals(reader);
                    dto = (T)parser.PopulateDTO(reader);
                    reader.Close();
                }
                else
                {
                    // S'il n'y a pas de données, nous renvoyons null.
                    dto = null;
                }
            }
            catch (Exception e)
            {
                throw new Exception("Error populating data", e);
            }
            finally
            {
                command.Connection.Close();
                command.Connection.Dispose();
            }
            // Renvoie le DTO, rempli soit avec des données soit avec null.
            return dto;
        }

        // GetDTOList
        protected static List<T> GetDTOList<T>(ref SqlCommand command) where T : DTOBase
        {
            List<T> dtoList = new List<T>();
            try
            {
                command.Connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                if (reader.HasRows)
                {
                    // Obtenir un analyseur (parser) pour ce type de DTO et remplir les ordinaux.
                    DTOParser parser = DTOParserFactory.GetParser(typeof(T));
                    parser.PopulateOrdinals(reader);
                    // Utilise l'analyseur (parser) pour construire notre liste de DTO.
                    while (reader.Read())
                    {
                        T dto = null;
                        dto = (T)parser.PopulateDTO(reader);
                        dtoList.Add(dto);
                    }
                    reader.Close();
                }
                else
                {
                    // S'il n'y a pas de données, nous renvoyons null.
                    dtoList = null;
                }
            }
            catch (Exception e)
            {
                throw new Exception("Error populating data", e);
            }
            finally
            {
                command.Connection.Close();
                command.Connection.Dispose();
            }
            return dtoList;
        }
    }
}
