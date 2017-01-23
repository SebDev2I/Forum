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
    /// Classe contenant les méthodes crud de la table MESSAGE
    /// </summary>
    public class MessageDb : DALBase
    {
        /// <summary>
        /// Méthode pour ramener la liste de tous les messages
        /// </summary>
        /// <returns></returns>
        public List<MessageDTO> GetAll()
        {
            SqlCommand command = GetDbSprocCommand("GETALLMESSAGE");
            return GetDTOList<MessageDTO>(ref command);
        }

        /// <summary>
        /// Méthode pour ramener un message par son id
        /// </summary>
        /// <param name="idmessage"></param>
        /// <returns></returns>
        public MessageDTO GetMessageById(int idmessage)
        {
            SqlCommand command = GetDbSprocCommand("GETMESSAGEBYID");
            command.Parameters.Add(CreateParameter("@ID", idmessage));
            return GetSingleDTO<MessageDTO>(ref command);
        }

        /// <summary>
        /// Méthode pour la liste des messages par topic
        /// </summary>
        /// <param name="idtopic"></param>
        /// <returns></returns>
        public List<MessageDTO> GetMessageByTopic(int idtopic)
        {
            SqlCommand command = GetDbSprocCommand("GETMESSAGEBYTOPIC");
            command.Parameters.Add(CreateParameter("@ID", idtopic));
            return GetDTOList<MessageDTO>(ref command);
        }

        /// <summary>
        /// Méthode pour ramener la liste des message par user
        /// </summary>
        /// <param name="iduser"></param>
        /// <returns></returns>
        public List<MessageDTO> GetMessageByUser(int iduser)
        {
            SqlCommand command = GetDbSprocCommand("GETMESSAGEBYUSER");
            command.Parameters.Add(CreateParameter("@ID", iduser));
            return GetDTOList<MessageDTO>(ref command);
        }

        /// <summary>
        /// Méthode pour sauvegarder un message (save et update)
        /// </summary>
        /// <param name="message"></param>
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
            command.Parameters.Add(CreateParameter("@CONTENTMESSAGE", message.ContentMessage, 2000000));

            // Exécute la commande.
            command.Connection.Open();
            int nb = command.ExecuteNonQuery();
            command.Connection.Close();
            if (nb == 1)
            {
                if (isNewRecord && nb == 1) { message.IdMessage = (int)paramNewMessageId.Value; }
            }
        }

        /// <summary>
        /// Méthode pour supprimer un message
        /// </summary>
        /// <param name="idmessage"></param>
        /// <returns></returns>
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
