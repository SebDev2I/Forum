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
    public class MessageDb : DALBase
    {
        public List<MessageDTO> GetAll()
        {
            SqlCommand command = GetDbSprocCommand("GETALLMESSAGE");
            return GetDTOList<MessageDTO>(ref command);
        }

        public MessageDTO GetMessageById(int idmessage)
        {
            SqlCommand command = GetDbSprocCommand("GETMESSAGEBYID");
            command.Parameters.Add(CreateParameter("@ID", idmessage));
            return GetSingleDTO<MessageDTO>(ref command);
        }

        public List<MessageDTO> GetMessageByTopic(int idtopic)
        {
            SqlCommand command = GetDbSprocCommand("GETMESSAGEBYTOPIC");
            command.Parameters.Add(CreateParameter("@ID", idtopic));
            return GetDTOList<MessageDTO>(ref command);
        }

        public List<MessageDTO> GetMessageByUser(int iduser)
        {
            SqlCommand command = GetDbSprocCommand("GETMESSAGEBYUSER");
            command.Parameters.Add(CreateParameter("@ID", iduser));
            return GetDTOList<MessageDTO>(ref command);
        }

        public void SaveMessage(ref MessageDTO message)
        {
            SqlCommand command = new SqlCommand();
            SqlParameter paramNewMessageId = new SqlParameter();
            bool isNewRecord = false;
            if (message.IdMessage.Equals(Common.DTOBase.Int_NullValue))
            {
                command = GetDbSprocCommand("INSERTMESSAGE");
                paramNewMessageId = CreateOutputParameter("@NEWMESSAGEID", SqlDbType.Int);
                command.Parameters.Add(paramNewMessageId);
                isNewRecord = true;
            }
            else
            {
                command = GetDbSprocCommand("UPDATEMESSAGE");
                command.Parameters.Add(CreateParameter("@ID", message.IdMessage));
            }

            command.Parameters.Add(CreateParameter("@IDTOPIC", message.IdTopic));
            command.Parameters.Add(CreateParameter("@IDUSER", message.IdUser));
            command.Parameters.Add(CreateParameter("@DATEMESSAGE", message.DateMessage));
            command.Parameters.Add(CreateParameter("@CONTENTMESSAGE", message.ContentMessage, 1024));

            // Exécute la commande.
            command.Connection.Open();
            int nb = command.ExecuteNonQuery();
            command.Connection.Close();
            if (nb == 1)
            {
                if (isNewRecord && nb == 1) { message.IdMessage = (int)paramNewMessageId.Value; }
            }
        }

        public bool DeleteMessage(int idmessage)
        {
            SqlCommand command = new SqlCommand();
            SqlParameter paramDeleted = new SqlParameter();
            bool isDeleted = false;
            command = GetDbSprocCommand("DELETEMESSAGE");
            command.Parameters.Add(CreateParameter("@ID", idmessage));

            command.Connection.Open();
            int nb = command.ExecuteNonQuery();
            command.Connection.Close();

            if (nb == 1) { isDeleted = true; }
            return isDeleted;
        }
    }
}
