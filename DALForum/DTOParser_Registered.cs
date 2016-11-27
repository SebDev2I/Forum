using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common;

namespace DALForum
{
    public class DTOParser_Registered : DTOParser
    {
        private int Ord_IdUser;
        private int Ord_IdStatus;
        private int Ord_IdTraining;
        private int Ord_Name;
        private int Ord_Firstname;
        private int Ord_Email;
        private int Ord_Login;
        private int Ord_Pwd;
        private int Ord_Keyword;
        public override DTOBase PopulateDTO(SqlDataReader reader)
        {
            RegisteredDTO r = new RegisteredDTO();
            if (!reader.IsDBNull(Ord_IdUser)) { r.IdUser = Convert.ToInt32(reader.GetDecimal(Ord_IdUser)); }
            if (!reader.IsDBNull(Ord_IdStatus)) { r.StatusUser = Convert.ToInt32(reader.GetDecimal(Ord_IdStatus)); }
            if (!reader.IsDBNull(Ord_IdTraining)) { r.TrainingUser = Convert.ToInt32(reader.GetDecimal(Ord_IdTraining)); }
            if (!reader.IsDBNull(Ord_Name)) { r.NameUser = reader.GetString(Ord_Name); }
            if (!reader.IsDBNull(Ord_Firstname)) { r.FirstnameUser = reader.GetString(Ord_Firstname); }
            if (!reader.IsDBNull(Ord_Email)) { r.EmailUser = reader.GetString(Ord_Email); }
            if (!reader.IsDBNull(Ord_Login)) { r.LoginUser = reader.GetString(Ord_Login); }
            if (!reader.IsDBNull(Ord_Pwd)) { r.PwdUser = reader.GetString(Ord_Pwd); }
            if (!reader.IsDBNull(Ord_Keyword)) { r.KeywordUser = reader.GetString(Ord_Keyword); }

            r.IsNew = true;
            return r;
        }

        public override void PopulateOrdinals(SqlDataReader reader)
        {
            Ord_IdUser = reader.GetOrdinal("ID_USER");
            Ord_IdStatus = reader.GetOrdinal("ID_STATUS");
            Ord_IdTraining = reader.GetOrdinal("ID_TRAINING");
            Ord_Name = reader.GetOrdinal("NAME");
            Ord_Firstname = reader.GetOrdinal("FIRSTNAME");
            Ord_Email = reader.GetOrdinal("EMAIL");
            Ord_Login = reader.GetOrdinal("LOGIN");
            Ord_Pwd = reader.GetOrdinal("PASSWORD");
            Ord_Keyword = reader.GetOrdinal("KEYWORD");
        }
    }
}
