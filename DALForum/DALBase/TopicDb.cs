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
    /// Classe contenant les méthodes crud de la table TOPIC
    /// </summary>
    public class TopicDb : DALBase
    {
        /// <summary>
        /// Méthode pour ramener la liste de tous les sujets
        /// </summary>
        /// <returns></returns>
        public List<TopicDTO> GetAll()
        {
            SqlCommand command = GetDbSprocCommand("GETALLTOPIC");
            return GetDTOList<TopicDTO>(ref command);
        }

        /// <summary>
        /// Méthode pour ramener un sujet par son id
        /// </summary>
        /// <param name="idtopic"></param>
        /// <returns></returns>
        public TopicDTO GetTopicById(int idtopic)
        {
            SqlCommand command = GetDbSprocCommand("GETTOPICBYID");
            command.Parameters.Add(CreateParameter("@ID", idtopic));
            return GetSingleDTO<TopicDTO>(ref command);
        }

        /// <summary>
        /// Méthode pour ramener la liste des sujets par rubrique
        /// </summary>
        /// <param name="idrubric"></param>
        /// <returns></returns>
        public List<TopicDTO> GetTopicByRubric(int idrubric)
        {
            SqlCommand command = GetDbSprocCommand("GETTOPICBYRUBRIC");
            command.Parameters.Add(CreateParameter("@ID", idrubric));
            return GetDTOList<TopicDTO>(ref command);
        }

        /// <summary>
        /// Méthode pour ramener la liste des sujets par user
        /// </summary>
        /// <param name="iduser"></param>
        /// <returns></returns>
        public List<TopicDTO> GetTopicByUser(int iduser)
        {
            SqlCommand command = GetDbSprocCommand("GETTOPICBYUSER");
            command.Parameters.Add(CreateParameter("@ID", iduser));
            return GetDTOList<TopicDTO>(ref command);
        }

        /// <summary>
        /// Méthode pour sauvegarder un sujet (save et update)
        /// </summary>
        /// <param name="topic"></param>
        public void SaveTopic(ref TopicDTO topic)
        {
            SqlCommand command = new SqlCommand();
            SqlParameter paramNewTopicId = new SqlParameter();
            bool isNewRecord = false;
            if (topic.IdTopic.Equals(Common.DTOBase.Int_NullValue))
            {
                command = GetDbSprocCommand("INSERTTOPIC");
                paramNewTopicId = CreateOutputParameter("@NEWTOPICID", SqlDbType.Int);
                command.Parameters.Add(paramNewTopicId);
                isNewRecord = true;
            }
            else
            {
                command = GetDbSprocCommand("UPDATETOPIC");
                command.Parameters.Add(CreateParameter("@ID", topic.IdTopic));
            }

            command.Parameters.Add(CreateParameter("@IDUSER", topic.IdUser));
            command.Parameters.Add(CreateParameter("@IDRUBRIC", topic.IdRubric));
            command.Parameters.Add(CreateParameter("@DATETOPIC", topic.DateTopic));
            command.Parameters.Add(CreateParameter("@TITLETOPIC", topic.TitleTopic, 50));
            command.Parameters.Add(CreateParameter("@DESCTOPIC", topic.DescTopic, 200000));

            // Exécute la commande.
            command.Connection.Open();
            int nb = command.ExecuteNonQuery();
            command.Connection.Close();
            if (nb == 1)
            {
                if (isNewRecord && nb == 1) { topic.IdTopic = (int)paramNewTopicId.Value; }
            }
        }

        /// <summary>
        /// Méthode pour supprimer un sujet
        /// </summary>
        /// <param name="idtopic"></param>
        /// <returns></returns>
        public bool DeleteTopic(int idtopic)
        {
            SqlCommand command = new SqlCommand();
            SqlParameter paramDeleted = new SqlParameter();
            bool isDeleted = false;
            command = GetDbSprocCommand("DELETETOPIC");
            command.Parameters.Add(CreateParameter("@ID", idtopic));

            command.Connection.Open();
            int nb = command.ExecuteNonQuery();
            command.Connection.Close();

            if (nb == 1) { isDeleted = true; }
            return isDeleted;
        }
    }
}
