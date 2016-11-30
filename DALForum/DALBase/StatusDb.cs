using Common;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DALForum
{
    public class StatusDb : DALBase
    {
        public List<StatusDTO> GetAll()
        {
            SqlCommand cmd = GetDbSprocCommand("GETALLSTATUS");
            return GetDTOList<StatusDTO>(ref cmd);
        }

        public StatusDTO GetStatusById(int idstatus)
        {
            SqlCommand command = GetDbSprocCommand("GETSTATUSBYID");
            command.Parameters.Add(CreateParameter("@ID", idstatus));
            return GetSingleDTO<StatusDTO>(ref command);
        }

        public void SaveStatus(ref StatusDTO status)
        {
            SqlCommand command = new SqlCommand();
            SqlParameter paramNewStatusId = new SqlParameter();
            bool isNewRecord = false;
            if (status.IdStatus.Equals(Common.DTOBase.Int_NullValue))
            {
                command = GetDbSprocCommand("INSERTSTATUS");
                paramNewStatusId = CreateOutputParameter("@NEWSTATUSID", SqlDbType.Int);
                command.Parameters.Add(paramNewStatusId);
                isNewRecord = true;
            }
            else
            {
                command = GetDbSprocCommand("UPDATESTATUS");
                command.Parameters.Add(CreateParameter("@ID", status.IdStatus));
            }

            command.Parameters.Add(CreateParameter("@NAME", status.NameStatus, 30));


            // Exécute la commande.
            command.Connection.Open();
            int nb = command.ExecuteNonQuery();
            command.Connection.Close();
            if (nb == 1)
            {
                if (isNewRecord && nb == 1) { status.IdStatus = (int)paramNewStatusId.Value; }
            }
        }

        public bool DeleteStatus(int idstatus)
        {
            SqlCommand command = new SqlCommand();
            SqlParameter paramDeleted = new SqlParameter();
            bool isDeleted = false;
            command = GetDbSprocCommand("DELETESTATUS");
            command.Parameters.Add(CreateParameter("@ID", idstatus));

            command.Connection.Open();
            int nb = command.ExecuteNonQuery();
            command.Connection.Close();

            if (nb == 1) { isDeleted = true; }
            return isDeleted;
        }
    }
}
