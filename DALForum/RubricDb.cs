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
    public class RubricDb : DALBase
    {
       public List<RubricDTO> GetAll()
        {
            SqlCommand cmd = GetDbSprocCommand("GETALLRUBRIC");
            return GetDTOList<RubricDTO>(ref cmd);
        }

        public RubricDTO GetRubricById(int idrubric)
        {
            SqlCommand command = GetDbSprocCommand("GETRUBRICBYID");
            command.Parameters.Add(CreateParameter("@ID", idrubric));
            return GetSingleDTO<RubricDTO>(ref command);
        }

        public void SaveRubric(ref RubricDTO rubric)
        {
            SqlCommand command = new SqlCommand();
            SqlParameter paramNewUserId = new SqlParameter();
            bool isNewRecord = false;
            if (rubric.IdRubric.Equals(Common.DTOBase.Int_NullValue))
            {
                command = GetDbSprocCommand("INSERTRUBRIC");
                paramNewUserId = CreateOutputParameter("@NEWUSERID", SqlDbType.Int);
                command.Parameters.Add(paramNewUserId);
                isNewRecord = true;
            }
            else
            {
                command = GetDbSprocCommand("UPDATERUBRIC");
                command.Parameters.Add(CreateParameter("@ID", rubric.IdRubric));
            }

            command.Parameters.Add(CreateParameter("@NAME", rubric.NameRubric, 50));
            

            // Exécute la commande.
            command.Connection.Open();
            int nb = command.ExecuteNonQuery();
            command.Connection.Close();
            if (nb == 1)
            {
                if (isNewRecord && nb == 1) { rubric.IdRubric = (int)paramNewUserId.Value; }
            }
        }

        public bool DeleteRubric(int idrubric)
        {
            SqlCommand command = new SqlCommand();
            SqlParameter paramDeleted = new SqlParameter();
            bool isDeleted = false;
            command = GetDbSprocCommand("DELETERUBRIC");
            command.Parameters.Add(CreateParameter("@ID", idrubric));

            command.Connection.Open();
            int nb = command.ExecuteNonQuery();
            command.Connection.Close();

            if (nb == 1) { isDeleted = true; }
            return isDeleted;
        }
    }
}
