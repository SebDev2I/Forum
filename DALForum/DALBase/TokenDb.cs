using Common;
using DLLAuth;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DALForum
{
    public class TokenDb : DALBase
    {
        private int ID_USER;
        private int LOGIN;
        private int PASSWORD;
        public Token GetAuh(Token token)
        {
            SqlCommand command = GetDbSprocCommand("GETAUTH");
            string[] body = TokenManager.GetBodyToken(token.TokenSpe);
            command.Parameters.Add(CreateParameter("@LOGIN", body[1], 50));
            command.Parameters.Add(CreateParameter("@PWD", body[0], 1024));
            command.Connection.Open();
            SqlDataReader reader = command.ExecuteReader();
            GetIndexField(reader);
            if (reader.HasRows)
            {
                reader.Read();
                int iduser = Convert.ToInt32(reader.GetDecimal(ID_USER));
                string login = reader.GetString(LOGIN);
                string pwd = reader.GetString(PASSWORD);
                pwd = Encoding.UTF8.GetString(Convert.FromBase64String(pwd), 0, Convert.FromBase64String(pwd).Length);
                pwd = TokenManager.GetPwd(pwd);
                long time = DateTime.UtcNow.Ticks;
                token = new Token(1, login, pwd, time);
                reader.Close();
                return token;
            }
            else
            {
                //token = null;
                return token;
            }

        }
        public RegisteredDTO GetInfoAuth(Token token)
        {
            SqlCommand command = GetDbSprocCommand("GETINFOAUTH");
            command.Parameters.Add(CreateParameter("@ID", token.IdUser));
            return GetSingleDTO<RegisteredDTO>(ref command);
        }

        private void GetIndexField(SqlDataReader r)
        {
            ID_USER = r.GetOrdinal("ID_USER");
            LOGIN = r.GetOrdinal("LOGIN");
            PASSWORD = r.GetOrdinal("PASSWORD");
        }
    }
}
