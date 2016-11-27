using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Common
{
    public class RegisteredDTO : DTOBase
    {
        public int IdUser { get; set; }
        public int StatusUser { get; set; }
        public int TrainingUser { get; set; }
        public string NameUser { get; set; }
        public string FirstnameUser { get; set; }
        public string EmailUser { get; set; }
        public string LoginUser { get; set; }
        public string PwdUser { get; set; }
        public string KeywordUser { get; set; }

        public RegisteredDTO()
        {
            IdUser = Int_NullValue;
            StatusUser = Int_NullValue;
            TrainingUser = Int_NullValue;
            NameUser = String_NullValue;
            FirstnameUser = String_NullValue;
            EmailUser = String_NullValue;
            LoginUser = String_NullValue;
            PwdUser = String_NullValue;
            KeywordUser = String_NullValue;
            IsNew = true;
        }
    }

}
