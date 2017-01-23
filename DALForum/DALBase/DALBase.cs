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
    /// <summary>
    /// Classe d'acceès aux données, elle contient les paramètres de connexion au sgbdr,
    /// 
    /// </summary>
    public abstract class DALBase
    {
        private static readonly string DATASOURCE = Properties.Settings.Default.datasource;
        private static readonly string DATABASE = Properties.Settings.Default.database;
        private static readonly string USERID = Properties.Settings.Default.userid;
        private static readonly string PWD = Properties.Settings.Default.pwd;
        private static StringBuilder CNXSTR = null;

        /// <summary>
        /// Méthode permettant de créer la chaîne de connexion pour l'accès à la bdd
        /// </summary>
        /// <returns></returns>
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

        /// <summary>
        /// Méthode pour créer une commande sql en passant une requête sql
        /// </summary>
        /// <param name="sqlQuery"></param>
        /// <returns></returns>
        protected static SqlCommand GetDbSQLCommand(string sqlQuery)
        {
            SqlCommand command = new SqlCommand();
            command.Connection = GetDbConnection();
            command.CommandType = CommandType.Text;
            command.CommandText = sqlQuery;
            return command;
        }

        /// <summary>
        /// Méthode pour ouvrir la connexion à la bdd
        /// </summary>
        /// <returns></returns>
        protected static SqlConnection GetDbConnection()
        {
            return new SqlConnection(ConnectionString);
        }

        /// <summary>
        /// Méthode permettant de créer une commande sql en passant le nom d'une procédure stockée
        /// </summary>
        /// <param name="sprocName"></param>
        /// <returns></returns>
        protected static SqlCommand GetDbSprocCommand(string sprocName)
        {
            SqlCommand command = new SqlCommand(sprocName);
            command.Connection = GetDbConnection();
            command.CommandType = CommandType.StoredProcedure;
            return command;
        }

        /// <summary>
        /// Méthode pour créer un paramètre d'entre de valeur null
        /// </summary>
        /// <param name="name"></param>
        /// <param name="paramType"></param>
        /// <returns></returns>
        protected static SqlParameter CreateNullParameter(string name, SqlDbType paramType)
        {
            SqlParameter parameter = new SqlParameter();
            parameter.SqlDbType = paramType;
            parameter.ParameterName = name;
            parameter.Value = null;
            parameter.Direction = ParameterDirection.Input;
            return parameter;
        }

        /// <summary>
        /// Méthode pour créer un paramètre d'entrée de type string null
        /// </summary>
        /// <param name="name"></param>
        /// <param name="paramType"></param>
        /// <param name="size"></param>
        /// <returns></returns>
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

        /// <summary>
        /// Méthode pour créer un paramètre de sortie avec son nom et son type
        /// </summary>
        /// <param name="name"></param>
        /// <param name="paramType"></param>
        /// <returns></returns>
        protected static SqlParameter CreateOutputParameter(string name, SqlDbType paramType)
        {
            SqlParameter parameter = new SqlParameter();
            parameter.SqlDbType = paramType;
            parameter.ParameterName = name;
            parameter.Direction = ParameterDirection.Output;
            return parameter;
        }

        /// <summary>
        /// Méthode pour créer un paramètre de sortie avec la taille de la chaîne, son type et son nom
        /// </summary>
        /// <param name="name"></param>
        /// <param name="paramType"></param>
        /// <param name="size"></param>
        /// <returns></returns>
        protected static SqlParameter CreateOutputParameter(string name, SqlDbType paramType, int size)
        {
            SqlParameter parameter = new SqlParameter();
            parameter.SqlDbType = paramType;
            parameter.Size = size;
            parameter.ParameterName = name;
            parameter.Direction = ParameterDirection.Output;
            return parameter;
        }
        
        /// <summary>
        /// Méthode pour créer un paramèrtre de type int
        /// </summary>
        /// <param name="name"></param>
        /// <param name="value"></param>
        /// <returns></returns>
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

        /// <summary>
        /// Méthode pour créer un paramètre de type datetime
        /// </summary>
        /// <param name="name"></param>
        /// <param name="value"></param>
        /// <returns></returns>
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

        /// <summary>
        /// Méthode pour créer un paramètre de type string avec la taille
        /// </summary>
        /// <param name="name"></param>
        /// <param name="value"></param>
        /// <param name="size"></param>
        /// <returns></returns>
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

        /// <summary>
        /// Méthode pour retourner un objet dto à partir du sqldatareader du résultat de la proc
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="command"></param>
        /// <returns></returns>
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

        /// <summary>
        /// Méthode pour retourner une liste de dto à partir du sqldatareader du résultat de la proc
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="command"></param>
        /// <returns></returns>
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
