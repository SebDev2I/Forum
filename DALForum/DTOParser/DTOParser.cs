using Common;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DALForum
{
    public abstract class DTOParser
    {
        abstract public DTOBase PopulateDTO(SqlDataReader reader);
        abstract public void PopulateOrdinals(SqlDataReader reader);
    }
}
