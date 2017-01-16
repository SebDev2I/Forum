using Common;
using DALClientWS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DLLForumV2
{
    /// <summary>
    /// Classe pour les messages du forum
    /// </summary>
    public class Message : ForumBase
    {
        /// <summary>
        /// Id du message
        /// </summary>
        public int IdMessage { get; set; }
        /// <summary>
        /// Id du topic
        /// </summary>
        public int IdTopic { get; set; }
        /// <summary>
        /// Utilisateur qui a créé le message
        /// </summary>
        public Registered ObjUser { get; set; }
        /// <summary>
        /// Date de création du message
        /// </summary>
        public DateTime DateMessage { get; set; }
        /// <summary>
        /// Contenu du message
        /// </summary>
        public string ContentMessage { get; set; }
        /// <summary>
        /// Message sous forme de dto
        /// </summary>
        public MessageDTO DTO { get; set; }
        /// <summary>
        /// Permet l'accès aux ressources du web service
        /// </summary>
        private DALClient dal { get; set; }

        /// <summary>
        /// Constructeur par défaut
        /// </summary>
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

        /// <summary>
        /// Constructeur pour mapper dto en Message
        /// </summary>
        /// <param name="dto"></param>
        /// <param name="objuser"></param>
        public Message(MessageDTO dto, Registered objuser) : this()
        {
            IdMessage = dto.IdMessage;
            IdTopic = dto.IdTopic;
            ObjUser = objuser;
            DateMessage = dto.DateMessage;
            ContentMessage = AuditTool.StringToRtf(dto.ContentMessage);
            DTO = dto;
        }

        /// <summary>
        /// Constructeur complet
        /// </summary>
        /// <param name="idmessage"></param>
        /// <param name="idtopic"></param>
        /// <param name="objuser"></param>
        /// <param name="datemessage"></param>
        /// <param name="contentmessage"></param>
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

        /// <summary>
        /// Validation des propriétés de message
        /// </summary>
        /// <returns></returns>
        public override List<ValidationError> Validate()
        {
            Val_Name();
            return this.ValidationErrors;
        }

        /// <summary>
        /// Méthode permettant de vérifier la validité du contenu du message, il ne peut être vide
        /// </summary>
        /// <returns></returns>
        private bool Val_Name()
        {
            int i = 0;
            if (ContentMessage == String_NullValue)
            {
                this.ValidationErrors.Add(new ValidationError("Message.ContentMessage", "Un message est requis"));
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
