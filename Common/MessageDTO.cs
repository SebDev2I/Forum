using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common
{
    public class MessageDTO : DTOBase
    {
        public int IdMessage { get; set; }
        public int IdTopic { get; set; }
        public int IdUser { get; set; }
        public DateTime DateMessage { get; set; }
        public string ContentMessage { get; set; }

        public MessageDTO()
        {
            IdMessage = Int_NullValue;
            IdTopic = Int_NullValue;
            IdUser = Int_NullValue;
            DateMessage = DateTime_NullValue;
            ContentMessage = String_NullValue;
            IsNew = true;
        }
    }
}
