using Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DLLForumV2
{
    public class Message : ForumBase
    {
        public int IdMessage { get; set; }
        public int IdTopic { get; set; }
        public int IdUser { get; set; }
        public DateTime DateMessage { get; set; }
        public string ContentMessage { get; set; }
        public MessageDTO DTO { get; set; }

        public Message()
        {
            IdMessage = Int_NullValue;
            IdTopic = Int_NullValue;
            IdUser = Int_NullValue;
            DateMessage = DateTime_NullValue;
            ContentMessage = String_NullValue;
            DTO = new MessageDTO();
        }

        public Message(MessageDTO dto)
        {
            IdMessage = dto.IdMessage;
            IdTopic = dto.IdTopic;
            IdUser = dto.IdUser;
            DateMessage = dto.DateMessage;
            ContentMessage = dto.ContentMessage;
        }

        public Message(int idmessage, int idtopic, int iduser, DateTime datemessage, string contentmessage)
        {
            IdMessage = idmessage;
            IdTopic = idtopic;
            IdUser = iduser;
            DateMessage = datemessage;
            ContentMessage = contentmessage;
            DTO = new MessageDTO();
            DTO.IdMessage = idmessage;
            DTO.IdTopic = idtopic;
            DTO.IdUser = iduser;
            DTO.DateMessage = datemessage;
            DTO.ContentMessage = contentmessage;
        }

        public override string ToString()
        {
            return "Idmessage : " + IdMessage
                + " Idtopic : " + IdTopic 
                + " Iduser : " + IdUser
                + " Date : " + DateMessage 
                + " Contenu : " + ContentMessage;
        }

        public override List<ValidationError> Validate()
        {
            Val_Name();
            return this.ValidationErrors;
        }

        private bool Val_Name()
        {
            int i = 0;
            if (ContentMessage == String_NullValue)
            {
                this.ValidationErrors.Add(new ValidationError("Message.ContentMessage", "<CONTENT_MESSAGE> est requis"));
                i++;
            }
            if (ContentMessage.Length > 1024)
            {
                this.ValidationErrors.Add(new ValidationError("Message.ContentMessage", "<CONTENT_MESSAGE> doit contenir 1024 caractères au maximum"));
                i++;
            }
            if (i > 0)
            {
                return false;
            }
            else return true;
        }
    }
}
