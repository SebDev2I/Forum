using Common;
using DLLAuth;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DLLAuth
{
    public class TokenManager
    {
        #region Attributs et propriétés
        private const string ALG = "HmacSHA256";
        private const string SALT = "rz8LuOtFBXphj9WQfvFh";
        public static int expMinute = 5;
        public static string[] Parts;
        #endregion

        #region Constructeurs

        #endregion

        #region Méthodes
        public static string GenerateTokenClient(string loginuser, string password)
        {
            string hash = string.Join(":", new string[] { loginuser, "2isaMillau%2016" });
            string hashLeft = "";
            string hashRight = "";

            hashLeft = Convert.ToBase64String(Encoding.UTF8.GetBytes(string.Join(":", hash, password)));
            hashRight = string.Join(":", new string[] { loginuser });
            return Convert.ToBase64String(Encoding.UTF8.GetBytes(string.Join(":", hashLeft, hashRight)));
        }

        public static string GenerateTokenWS(string loginuser, string password)
        {
            string hash = string.Join(":", new string[] { loginuser, "2isaMillau%2016" });
            string hashLeft = password;
            string hashRight = "";

            //hashLeft = Convert.ToBase64String(Encoding.UTF8.GetBytes(string.Join(":", hash, password)));
            hashRight = string.Join(":", new string[] { loginuser });
            return Convert.ToBase64String(Encoding.UTF8.GetBytes(string.Join(":", hashLeft, hashRight)));
        }

        public static bool IsTokenValid(Token token, RegisteredDTO registered)
        {
            bool result = false;
            long timeStamp = token.Time;
            DateTime ts = new DateTime(timeStamp);
            long date = DateTime.UtcNow.Ticks;
            DateTime d = new DateTime(date);
            int iduser = token.IdUser;
            bool expired = Math.Abs((d - ts).TotalMinutes) > expMinute;

            if (!expired)
            {
                string computedToken = GenerateTokenWS(registered.LoginUser, registered.PwdUser);
                result = (token.TokenSpe == computedToken);
            }
            return result;
        }

        public static string[] GetBodyToken(string token)
        {
            string key = Encoding.UTF8.GetString(Convert.FromBase64String(token), 0, Convert.FromBase64String(token).Length);

            // Split the parts.
            Parts = key.Split(new char[] { ':' });
            return Parts;
        }
        #endregion
    }
}
