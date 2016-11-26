using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace DLLForum
{
    [DataContract]
    /// <summary>
    /// Personne enregistrée dans la base de données
    /// </summary>
    public class Registered
    {
        #region Attributs et propriétés
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
        #endregion

        #region "Méthodes redéfinies"
        public override string ToString()
        {
            return " Id : " + _IdUser + " Statut : " + _StatusUser + " Training : " + _TrainingUser +
                " Nom : " + _NameUser + " Prénom : " + _FirstnameUser + " Email : " + _EmailUser
                + " Login : " + _LoginUser + " Pwd : " + _PwdUser + " Mot-clé : " + _KeywordUser;
        }
        #endregion
    }
}

