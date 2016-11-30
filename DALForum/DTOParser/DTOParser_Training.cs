using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common;

namespace DALForum
{
    public class DTOParser_Training : DTOParser
    {
        private int Ord_IdTraining;
        private int Ord_NameTraining;

        public override DTOBase PopulateDTO(SqlDataReader reader)
        {
            TrainingDTO t = new TrainingDTO();
            if (!reader.IsDBNull(Ord_IdTraining)) { t.IdTraining = Convert.ToInt32(reader.GetDecimal(Ord_IdTraining)); }
            if (!reader.IsDBNull(Ord_NameTraining)) { t.NameTraining = reader.GetString(Ord_NameTraining); }

            t.IsNew = true;
            return t;
        }

        public override void PopulateOrdinals(SqlDataReader reader)
        {
            Ord_IdTraining = reader.GetOrdinal("ID_TRAINING");
            Ord_NameTraining = reader.GetOrdinal("NAME_TRAINING");
        }
    }
}
