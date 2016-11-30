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
        private const int ID_USER = 0;
        private const int LOGIN = 1;
        private const int PASSWORD = 2;
        public Token GetAuh(Token token)
        {
            SqlCommand command = GetDbSprocCommand("GETAUTH");
            string[] body = TokenManager.GetBodyToken(token.TokenSpe);
            command.Parameters.Add(CreateParameter("@LOGIN", body[1], 50));
            command.Parameters.Add(CreateParameter("@PWD", body[0], 1024));
            command.Connection.Open();
            SqlDataReader reader = command.ExecuteReader();
            if (reader.HasRows)
            {
                int iduser = Convert.ToInt32(reader.GetDecimal(ID_USER));
                string login = reader.GetString(LOGIN);
                string pwd = reader.GetString(PASSWORD);
                long time = DateTime.UtcNow.Ticks;
                token = new Token(iduser, login, pwd, time);
                reader.Close();
                return token;
            }
            else
            {
                token = null;
                return token;
            }

        }
        public RegisteredDTO GetInfoAuth(Token token)
        {
            SqlCommand command = GetDbSprocCommand("GETINFOAUTH");
            command.Parameters.Add(CreateParameter("@ID", token.IdUser));
            return GetSingleDTO<RegisteredDTO>(ref command);
        }
    }
}
