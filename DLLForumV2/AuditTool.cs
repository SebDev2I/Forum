using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace DLLForumV2
{
    public static class AuditTool
    {
        public static bool IsEmail(string email)
        {
            string pattern = "^([0-9a-zA-Z]([-\\.\\w]*[0-9a-zA-Z])*@([0-9a-zA-Z][-\\w]*[0-9a-zA-Z]\\.)+[a-zA-Z]{2,9})$";
            if (Regex.IsMatch(email, pattern))
            {
                return true;
            }
            else return false;
        }

        public static bool IsAlpha(string str)
        {
            string pattern = @"\d";

            if (Regex.IsMatch(str, pattern))
            {
                return false;
            }
            else return true;
        }

        public static string RtfToString(string rtf)
        {
            if (rtf != null)
            {
                return Convert.ToBase64String(Encoding.UTF8.GetBytes(rtf));
            }
            return null;
        }

        public static string StringToRtf(string str)
        {
            if(str != null && Convert.FromBase64String(str).Length>0)
            {
                return Encoding.UTF8.GetString(Convert.FromBase64String(str), 0, Convert.FromBase64String(str).Length);
            }
            return null;
        }
    }
}
