using DLLForumV2;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace DLLForum
{
    /// <summary>
    /// Personne enregistrée dans la base de données
    /// </summary>
    public class Registered : ForumBase
    {
        public RegisteredDTO Data { get; set; }
        public Status DataStatus { get; set; }
        public Training DataTraining { get; set; }
        public Registered()
        {
            this.Data = new RegisteredDTO();
            this.DataStatus = new Status();
        }
        public Registered(RegisteredDTO dto, Status status, Training training)
        {
            this.Data = dto;
            this.DataStatus = status;
            this.DataTraining = training;
        }

        public override List<ValidationError> Validate()
        {
            Val_Name();
            return this.ValidationErrors;
        }

        private bool Val_Name()
        {
            int i = 0;
            if (Data.NameUser == DTOBase.String_NullValue)
            {
                this.ValidationErrors.Add(new ValidationError("Registered.NameUser", "<NAME> est requis"));
                i++;
            }
            else if (Data.NameUser.Length > 50)
            {
                this.ValidationErrors.Add(new ValidationError("Registered.NameUser", "<NAME> doit contenir 50 caractères au maximum"));
                i++;
            }
            else if (!AuditTool.IsAlpha(Data.NameUser))
            {
                this.ValidationErrors.Add(new ValidationError("Registered.NameUser", "<NAME> ne peut contenir de chiffres"));
                i++;
            }
            else if (Data.FirstnameUser == DTOBase.String_NullValue)
            {
                this.ValidationErrors.Add(new ValidationError("Registered.FirstNameUser", "<FIRSTNAME> est requis"));
                i++;
            }
            else if (Data.FirstnameUser.Length > 50)
            {
                this.ValidationErrors.Add(new ValidationError("Registered.FirstNameUser", "<FIRSTNAME> doit contenir 50 caractères au maximum"));
                i++;
            }
            else if (!AuditTool.IsAlpha(Data.FirstnameUser))
            {
                this.ValidationErrors.Add(new ValidationError("Registered.FirstNameUser", "<FIRSTNAME> ne peut contenir de chiffres"));
                i++;
            }
            if(i > 0)
            {
                return false;
            }
            else return true;
        }

        private bool Val_Email()
        {
            if (!AuditTool.IsEmail(Data.EmailUser))
            {
                this.ValidationErrors.Add(new ValidationError("Registered.EmailUser", "<EMAIL> ne correspond pas au format email"));
                return false;
            }
            else if (Data.EmailUser.Length > 100)
            {
                this.ValidationErrors.Add(new ValidationError("Registered.EmailUser", "<EMAIL> doit contenir 100 caractères au maximum"));
                return false;
            }
            else return true;
        }

        /*#region Attributs et propriétés
        private int _IdUser;
        [DataMember(Order = 1)]
        public int IdUser
        {
            get { return _IdUser; }
            set { _IdUser = value; }
        }

        private int _StatusUser;
        [DataMember(Order = 2)]
        public int StatusUser
        {
            get { return _StatusUser; }
            set { _StatusUser = value; }
        }

        private int _TrainingUser;
        [DataMember(Order = 3)]
        public int TrainingUser
        {
            get { return _TrainingUser; }
            set { _TrainingUser = value; }
        }

        private string _NameUser;
        [DataMember(Order = 4)]
        public string NameUser
        {
            get { return _NameUser; }
            set { _NameUser = value; }
        }

        private string _FirstnameUser;
        [DataMember(Order = 5)]
        public string FirstnameUser
        {
            get { return _FirstnameUser; }
            set { _FirstnameUser = value; }
        }

        private string _EmailUser;
        [DataMember(Order = 6)]
        public string EmailUser
        {
            get { return _EmailUser; }
            set { _EmailUser = value; }
        }

        private string _LoginUser;
        [DataMember(Order = 7)]
        public string LoginUser
        {
            get { return _LoginUser; }
            set { _LoginUser = value; }
        }

        private string _PwdUser;
        [DataMember(Order = 8)]
        public string PwdUser
        {
            get { return _PwdUser; }
            set { _PwdUser = value; }
        }

        private string _KeywordUser;
        [DataMember(Order = 9)]
        public string KeywordUser
        {
            get { return _KeywordUser; }
            set { _KeywordUser = value; }
        }
        #endregion

        #region Constructeurs
        /// <summary>
        /// Constructeur par défaut
        /// </summary>
        public Registered()
        {
            this.IdUser = 0;
            this.StatusUser = 0;
            this.TrainingUser = 0;
            this.NameUser = "NomEssai";
            this.FirstnameUser = "PrénomEssai";
            this.EmailUser = "email.essai@2isa.org";
            this.LoginUser = "LoginEssai";
            this.PwdUser = "PwdEssai";
            this.KeywordUser = "KeywordEssai";


        }
        /// <summary>
        /// Constructeur n'utilisant que les données de connexion
        /// </summary>
        /// <param name="login"></param>
        /// <param name="pwd"></param>
        public Registered(string login, string pwd) : this()
        {
            this.LoginUser = login;
            this.PwdUser = pwd;
        }
        /// <summary>
        /// Constructeur complet
        /// </summary>
        /// <param name="iduser"></param>
        /// <param name="statususer"></param>
        /// <param name="traininguser"></param>
        /// <param name="nameuser"></param>
        /// <param name="firstnameuser"></param>
        /// <param name="emailuser"></param>
        /// <param name="loginuser"></param>
        /// <param name="pwduser"></param>
        /// <param name="keyworduser"></param>
        public Registered(int iduser, int statususer, int traininguser, string nameuser, string firstnameuser, string emailuser,
            string loginuser, string pwduser, string keyworduser)
        {
            this.IdUser = iduser;
            this.StatusUser = statususer;
            this.TrainingUser = traininguser;
            this.NameUser = nameuser;
            this.FirstnameUser = firstnameuser;
            this.EmailUser = emailuser;
            this.LoginUser = loginuser;
            this.PwdUser = pwduser;
            this.KeywordUser = keyworduser;

        }
        #endregion

        #region Méthodes
        /// <summary>
        /// Méthode de connexion
        /// </summary>
        public void Login()
        {

        }
        /// <summary>
        /// Méthode de déconnexion
        /// </summary>
        public void SignOut()
        {

        }

        /// <summary>
        /// Méthode d'édition des informations sur une personne
        /// </summary>
        public virtual void EditInfoPerson()
        {

        }

        /// <summary>
        /// Méthode de création de topic
        /// </summary>
        /// <param name="topic"></param>
        public void AddTopic(Topic topic)
        {

        }

        /// <summary>
        /// Méthode de création de message
        /// </summary>
        /// <param name="msg"></param>
        public void AddMessage(Message msg)
        {

        }
        #endregion*/

        #region "Méthodes redéfinies"
        public override string ToString()
        {
            return "Id : " + Data.IdUser 
                + " Statut : " + DataStatus.Data.NameStatus 
                + " Training : " + DataTraining.Data.NameTraining 
                + " Nom : " + Data.NameUser 
                + " Prénom : " + Data.FirstnameUser 
                + " Email : " + Data.EmailUser
                + " Login : " + Data.LoginUser 
                + " Pwd : " + Data.PwdUser 
                + " Mot-clé : " + Data.KeywordUser;
        }
        #endregion
    }
}

