using Common;
using DALClientWS;
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
        public Registered ObjUser { get; set; }
        public DateTime DateMessage { get; set; }
        public string ContentMessage { get; set; }
        public MessageDTO DTO { get; set; }
        private DALClient dal { get; set; }

        public Message()
        {
            dal = new DALClient();
            IdMessage = Int_NullValue;
            IdTopic = Int_NullValue;
            ObjUser = null;
            DateMessage = DateTime_NullValue;
            ContentMessage = String_NullValue;
            DTO = new MessageDTO();
        }

        public Message(MessageDTO dto, Registered objuser) : this()
        {
            IdMessage = dto.IdMessage;
            IdTopic = dto.IdTopic;
            ObjUser = objuser;
            DateMessage = dto.DateMessage;
            ContentMessage = AuditTool.StringToRtf(dto.ContentMessage);
            DTO = dto;
        }

        public Message(int idmessage, int idtopic, Registered objuser, DateTime datemessage, string contentmessage) : this()
        {
            IdMessage = idmessage;
            IdTopic = idtopic;
            ObjUser = objuser;
            DateMessage = datemessage;
            ContentMessage = AuditTool.RtfToString(contentmessage);
            DTO = new MessageDTO();
            DTO.IdMessage = idmessage;
            DTO.IdTopic = idtopic;
            DTO.IdUser = objuser.IdUser;
            DTO.DateMessage = datemessage;
            DTO.ContentMessage = ContentMessage;
        }

        public override string ToString()
        {
            return "Idmessage : " + IdMessage
                + " Idtopic : " + IdTopic 
                + " User : " + ObjUser
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
            if (i > 0)
            {
                return false;
            }
            else return true;
        }
    }
}
