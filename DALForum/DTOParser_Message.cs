using Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace DALForum
{
    public class DTOParser_Message : DTOParser
    {
        private int Ord_IdMessage;
        private int Ord_IdTopic;
        private int Ord_IdUser;
        private int Ord_DateMessage;
        private int Ord_ContentMessage;

        public override DTOBase PopulateDTO(SqlDataReader reader)
        {
            MessageDTO m = new MessageDTO();
            if (!reader.IsDBNull(Ord_IdMessage)) { m.IdMessage = Convert.ToInt32(reader.GetDecimal(Ord_IdMessage)); }
            if (!reader.IsDBNull(Ord_IdTopic)) { m.IdTopic = Convert.ToInt32(reader.GetDecimal(Ord_IdTopic)); }
            if (!reader.IsDBNull(Ord_IdUser)) { m.IdUser = Convert.ToInt32(reader.GetDecimal(Ord_IdUser)); }
            if (!reader.IsDBNull(Ord_DateMessage)) { m.DateMessage = reader.GetDateTime(Ord_DateMessage); }
            if (!reader.IsDBNull(Ord_ContentMessage)) { m.ContentMessage = reader.GetString(Ord_ContentMessage); }

            m.IsNew = true;
            return m;
        }

        public override void PopulateOrdinals(SqlDataReader reader)
        {
            Ord_IdMessage = reader.GetOrdinal("ID_MESSAGE");
            Ord_IdTopic = reader.GetOrdinal("ID_TOPIC");
            Ord_IdUser = reader.GetOrdinal("ID_USER");
            Ord_DateMessage = reader.GetOrdinal("DATE_MESSAGE");
            Ord_ContentMessage = reader.GetOrdinal("CONTENT_MESSAGE");
        }
    }
}
