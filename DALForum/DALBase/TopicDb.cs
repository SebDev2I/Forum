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
    public class TopicDb : DALBase
    {
        public List<TopicDTO> GetAll()
        {
            SqlCommand command = GetDbSprocCommand("GETALLTOPIC");
            return GetDTOList<TopicDTO>(ref command);
        }

        public TopicDTO GetTopicById(int idtopic)
        {
            SqlCommand command = GetDbSprocCommand("GETTOPICBYID");
            command.Parameters.Add(CreateParameter("@ID", idtopic));
            return GetSingleDTO<TopicDTO>(ref command);
        }

        public List<TopicDTO> GetTopicByRubric(int idrubric)
        {
            SqlCommand command = GetDbSprocCommand("GETTOPICBYRUBRIC");
            command.Parameters.Add(CreateParameter("@ID", idrubric));
            return GetDTOList<TopicDTO>(ref command);
        }

        public List<TopicDTO> GetTopicByUser(int iduser)
        {
            SqlCommand command = GetDbSprocCommand("GETTOPICBYUSER");
            command.Parameters.Add(CreateParameter("@ID", iduser));
            return GetDTOList<TopicDTO>(ref command);
        }

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
            command.Parameters.Add(CreateParameter("@DESCTOPIC", topic.DescTopic, 1024));

            // Exécute la commande.
            command.Connection.Open();
            int nb = command.ExecuteNonQuery();
            command.Connection.Close();
            if (nb == 1)
            {
                if (isNewRecord && nb == 1) { topic.IdTopic = (int)paramNewTopicId.Value; }
            }
        }

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
