using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Common
{
    /// <summary>
    /// Classe dto représentant l'ensemble des données d'un utilisateur
    /// </summary>
    [DataContract]
    public class RegisteredDTO : DTOBase
    {
        [DataMember]
        public int IdUser { get; set; }
        [DataMember]
        public int StatusUser { get; set; }
        [DataMember]
        public int TrainingUser { get; set; }
        [DataMember]
        public string NameUser { get; set; }
        [DataMember]
        public string FirstnameUser { get; set; }
        [DataMember]
        public string EmailUser { get; set; }
        [DataMember]
        public string LoginUser { get; set; }
        [DataMember]
        public string PwdUser { get; set; }
        [DataMember]
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

        public override string ToString()
        {
            return " Id : " + IdUser + " Statut : " + StatusUser + " Training : " + TrainingUser +
                " Nom : " + NameUser + " Prénom : " + FirstnameUser + " Email : " + EmailUser
                + " Login : " + LoginUser + " Pwd : " + PwdUser + " Mot-clé : " + KeywordUser;
        }
    }

}
