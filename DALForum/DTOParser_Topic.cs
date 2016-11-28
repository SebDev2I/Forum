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
            
        }

        public override void PopulateOrdinals(SqlDataReader reader)
        {
            throw new NotImplementedException();
        }
    }
}
