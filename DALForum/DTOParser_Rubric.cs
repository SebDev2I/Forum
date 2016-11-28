using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common;

namespace DALForum
{
    public class DTOParser_Rubric : DTOParser
    {
        private int Ord_IdRubric;
        private int Ord_NameRubric;

        public override DTOBase PopulateDTO(SqlDataReader reader)
        {
            RubricDTO r = new RubricDTO();
            if (!reader.IsDBNull(Ord_IdRubric)) { r.IdRubric = Convert.ToInt32(reader.GetDecimal(Ord_IdRubric)); }
            if (!reader.IsDBNull(Ord_NameRubric)) { r.NameRubric = reader.GetString(Ord_NameRubric); }

            r.IsNew = true;
            return r;
        }

        public override void PopulateOrdinals(SqlDataReader reader)
        {
            Ord_IdRubric = reader.GetOrdinal("ID_RUBRIC");
            Ord_NameRubric = reader.GetOrdinal("NAME_RUBRIC");
        }
    }
}
