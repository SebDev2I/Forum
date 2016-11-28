using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common;

namespace DALForum
{
    public class DTOParser_Status : DTOParser
    {
        private int Ord_IdStatus;
        private int Ord_NameStatus;

        public override DTOBase PopulateDTO(SqlDataReader reader)
        {
            StatusDTO s = new StatusDTO();
            if (!reader.IsDBNull(Ord_IdStatus)) { s.IdStatus = Convert.ToInt32(reader.GetDecimal(Ord_IdStatus)); }
            if (!reader.IsDBNull(Ord_NameStatus)) { s.NameStatus = reader.GetString(Ord_NameStatus); }

            s.IsNew = true;
            return s;
        }

        public override void PopulateOrdinals(SqlDataReader reader)
        {
            Ord_IdStatus = reader.GetOrdinal("ID_STATUS");
            Ord_NameStatus = reader.GetOrdinal("NAME_STATUS");
        }
    }
}
