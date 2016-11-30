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
    public class TrainingDb : DALBase
    {
        public List<TrainingDTO> GetAll()
        {
            SqlCommand cmd = GetDbSprocCommand("GETALLTRAINING");
            return GetDTOList<TrainingDTO>(ref cmd);
        }

        public TrainingDTO GetTrainingById(int idtraining)
        {
            SqlCommand command = GetDbSprocCommand("GETTRAININGBYID");
            command.Parameters.Add(CreateParameter("@ID", idtraining));
            return GetSingleDTO<TrainingDTO>(ref command);
        }

        public void SaveTraining(ref TrainingDTO training)
        {
            SqlCommand command = new SqlCommand();
            SqlParameter paramNewTrainingId = new SqlParameter();
            bool isNewRecord = false;
            if (training.IdTraining.Equals(Common.DTOBase.Int_NullValue))
            {
                command = GetDbSprocCommand("INSERTTRAINING");
                paramNewTrainingId = CreateOutputParameter("@NEWTRAININGID", SqlDbType.Int);
                command.Parameters.Add(paramNewTrainingId);
                isNewRecord = true;
            }
            else
            {
                command = GetDbSprocCommand("UPDATETRAINING");
                command.Parameters.Add(CreateParameter("@ID", training.IdTraining));
            }

            command.Parameters.Add(CreateParameter("@NAME", training.NameTraining, 30));


            // Exécute la commande.
            command.Connection.Open();
            int nb = command.ExecuteNonQuery();
            command.Connection.Close();
            if (nb == 1)
            {
                if (isNewRecord && nb == 1) { training.IdTraining = (int)paramNewTrainingId.Value; }
            }
        }

        public bool DeleteTraining(int idtraining)
        {
            SqlCommand command = new SqlCommand();
            SqlParameter paramDeleted = new SqlParameter();
            bool isDeleted = false;
            command = GetDbSprocCommand("DELETETRAINING");
            command.Parameters.Add(CreateParameter("@ID", idtraining));

            command.Connection.Open();
            int nb = command.ExecuteNonQuery();
            command.Connection.Close();

            if (nb == 1) { isDeleted = true; }
            return isDeleted;
        }
    }
}
