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
    /// <summary>
    /// Méthode contenant les méthodes crud de la table RUBRIC
    /// </summary>
    public class RubricDb : DALBase
    {
        /// <summary>
        /// Méthode permettant de ramener la liste de toutes les rubriques
        /// </summary>
        /// <returns></returns>
       public List<RubricDTO> GetAll()
        {
            SqlCommand cmd = GetDbSprocCommand("GETALLRUBRIC");
            return GetDTOList<RubricDTO>(ref cmd);
        }

        /// <summary>
        /// Méthode pour ramener une rubrique
        /// </summary>
        /// <param name="idrubric"></param>
        /// <returns></returns>
        public RubricDTO GetRubricById(int idrubric)
        {
            SqlCommand command = GetDbSprocCommand("GETRUBRICBYID");
            command.Parameters.Add(CreateParameter("@ID", idrubric));
            return GetSingleDTO<RubricDTO>(ref command);
        }

        /// <summary>
        /// Méthode pour sauvegarder une rubrique (save et update)
        /// </summary>
        /// <param name="rubric"></param>
        public void SaveRubric(ref RubricDTO rubric)
        {
            SqlCommand command = new SqlCommand();
            SqlParameter paramNewRubricId = new SqlParameter();
            bool isNewRecord = false;
            if (rubric.IdRubric.Equals(Common.DTOBase.Int_NullValue))
            {
                command = GetDbSprocCommand("INSERTRUBRIC");
                paramNewRubricId = CreateOutputParameter("@NEWRUBRICID", SqlDbType.Int);
                command.Parameters.Add(paramNewRubricId);
                isNewRecord = true;
            }
            else
            {
                command = GetDbSprocCommand("UPDATERUBRIC");
                command.Parameters.Add(CreateParameter("@ID", rubric.IdRubric));
            }

            command.Parameters.Add(CreateParameter("@NAME", rubric.NameRubric, 10));
            

            // Exécute la commande.
            command.Connection.Open();
            int nb = command.ExecuteNonQuery();
            command.Connection.Close();
            if (nb == 1)
            {
                if (isNewRecord && nb == 1) { rubric.IdRubric = (int)paramNewRubricId.Value; }
            }
        }

        /// <summary>
        /// Méthode pour supprimer une rubrique
        /// </summary>
        /// <param name="idrubric"></param>
        /// <returns></returns>
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
