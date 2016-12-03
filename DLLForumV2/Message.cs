using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DLLForumV2
{
    public class Message
    {
        public int IdMessage { get; set; }
        public int IdTopic { get; set; }
        public int IdUser { get; set; }
        public DateTime DateMessage { get; set; }
        public string ContentMessage { get; set; }

        public Message()
        {
        }

        public override string ToString()
        {
            return "Idmessage : " + IdMessage
                + " Idtopic : " + IdTopic 
                + " Iduser : " + IdUser
                + " Date : " + DateMessage 
                + " Contenu : " + ContentMessage;
        }
    }
}
