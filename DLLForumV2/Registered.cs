using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace DLLForumV2
{
    public class Registered
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

        public Registered()
        {
        }

        public override string ToString()
        {
            return "Id : " + IdUser 
                + " Statut : " + StatusUser 
                + " Training : " + TrainingUser 
                + " Nom : " + NameUser 
                + " Prénom : " + FirstnameUser 
                + " Email : " + EmailUser
                + " Login : " + LoginUser 
                + " Pwd : " + PwdUser 
                + " Mot-clé : " + KeywordUser;
        }
    }

}
