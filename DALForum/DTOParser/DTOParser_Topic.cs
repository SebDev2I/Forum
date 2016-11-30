using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common;

namespace DALForum
{
    public class DTOParser_Topic : DTOParser
    {
        private int Ord_IdTopic;
        private int Ord_IdUser;
        private int Ord_IdRubric;
        private int Ord_DateTopic;
        private int Ord_TitleTopic;
        private int Ord_DescTopic;

        public override DTOBase PopulateDTO(SqlDataReader reader)
        {
            TopicDTO t = new TopicDTO();
            if (!reader.IsDBNull(Ord_IdTopic)) { t.IdTopic = Convert.ToInt32(reader.GetDecimal(Ord_IdTopic)); }
            if (!reader.IsDBNull(Ord_IdUser)) { t.IdUser = Convert.ToInt32(reader.GetDecimal(Ord_IdUser)); }
            if (!reader.IsDBNull(Ord_IdRubric)) { t.IdRubric = Convert.ToInt32(reader.GetDecimal(Ord_IdRubric)); }
            if (!reader.IsDBNull(Ord_DateTopic)) { t.DateTopic = reader.GetDateTime(Ord_DateTopic); }
            if (!reader.IsDBNull(Ord_DescTopic)) { t.DescTopic = reader.GetString(Ord_DescTopic); }

            t.IsNew = true;
            return t;
        }

        public override void PopulateOrdinals(SqlDataReader reader)
        {
            Ord_IdTopic = reader.GetOrdinal("ID_TOPIC");
            Ord_IdUser = reader.GetOrdinal("ID_USER");
            Ord_IdRubric = reader.GetOrdinal("ID_RUBRIC");
            Ord_DateTopic = reader.GetOrdinal("DATE_TOPIC");
            Ord_TitleTopic = reader.GetOrdinal("TITLE_TOPIC");
            Ord_DescTopic = reader.GetOrdinal("DESC_TOPIC");
        }
    }
}
