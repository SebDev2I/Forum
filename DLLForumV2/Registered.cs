using Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace DLLForumV2
{
    public class Registered : ForumBase
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
        public RegisteredDTO DTO { get; set; }

        public Registered()
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
            DTO = new RegisteredDTO();
        }

        public Registered(RegisteredDTO dto)
        {
            IdUser = dto.IdUser;
            StatusUser = dto.StatusUser;
            TrainingUser = dto.TrainingUser;
            NameUser = dto.NameUser;
            FirstnameUser = dto.FirstnameUser;
            EmailUser = dto.EmailUser;
            LoginUser = dto.LoginUser;
            PwdUser = dto.PwdUser;
            KeywordUser = dto.KeywordUser;
        }

        public Registered(int iduser, int idstatus, int idtraining, string nameuser, string firstnameuser, 
            string emailuser, string loginuser, string pwduser, string keyworduser)
        {
            IdUser = iduser;
            StatusUser = idstatus;
            TrainingUser = idtraining;
            NameUser = nameuser;
            FirstnameUser = firstnameuser;
            EmailUser = emailuser;
            LoginUser = loginuser;
            PwdUser = pwduser;
            KeywordUser = keyworduser;
            DTO = new RegisteredDTO();
            DTO.IdUser = iduser;
            DTO.StatusUser = idstatus;
            DTO.TrainingUser = idtraining;
            DTO.NameUser = nameuser;
            DTO.FirstnameUser = firstnameuser;
            DTO.EmailUser = emailuser;
            DTO.LoginUser = loginuser;
            DTO.PwdUser = pwduser;
            DTO.KeywordUser = keyworduser;
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

        public override List<ValidationError> Validate()
        {
            Val_Name();
            Val_Email();
            Val_Login();
            Val_Pwd();
            return this.ValidationErrors;
        }

        private bool Val_Name()
        {

        }

        private bool Val_Email()
        {

        }

        private bool Val_Login()
        {

        }

        private bool Val_Pwd()
        {

        }
    }

}
