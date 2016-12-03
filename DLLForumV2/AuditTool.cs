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
    }
}
