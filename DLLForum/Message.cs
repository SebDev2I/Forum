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
    /// Les messages du forum
    /// </summary>
    public class Message
    {
        #region Attributs et propriétés
        private int _IdMessage;
        [DataMember(Order = 1)]
        public int IdMessage
        {
            get { return _IdMessage; }
            set { _IdMessage = value; }
        }

        private int _IdTopic;
        [DataMember(Order = 2)]
        public int IdTopic
        {
            get { return _IdTopic; }
            set { _IdTopic = value; }
        }

        private int _IdUser;
        [DataMember(Order = 3)]
        public int IdUser
        {
            get { return _IdUser; }
            set { _IdUser = value; }
        }


        private DateTime _DateMessage;
        [DataMember(Order = 4)]
        public DateTime DateMessage
        {
            get { return _DateMessage; }
            set { _DateMessage = value; }
        }

        private string _ContentMessage;
        [DataMember(Order = 5)]
        public string ContentMessage
        {
            get { return _ContentMessage; }
            set { _ContentMessage = value; }
        }

        #endregion

        #region Constructeurs
        /// <summary>
        /// Constructeur par défaut
        /// </summary>
        public Message()
        {
            _IdMessage = 0;
            _IdTopic = 0;
            _IdUser = 0;
            _DateMessage = System.DateTime.Now;
            _ContentMessage = "Ceci est un message d'essai";
        }

        /// <summary>
        /// Constructeur complet
        /// </summary>
        /// <param name="idmessage"></param>
        /// <param name="idtopic"></param>
        /// <param name="iduser"></param>
        /// <param name="datemessage"></param>
        /// <param name="contentmessage"></param>
        public Message(int idmessage, int idtopic, int iduser, DateTime datemessage, string contentmessage)
        {
            _IdMessage = idmessage;
            _IdTopic = idtopic;
            _IdUser = iduser;
            _DateMessage = datemessage;
            _ContentMessage = contentmessage;
        }
        #endregion

        #region Méthodes

        #endregion

        #region "Méthodes redéfinies"
        public override string ToString()
        {
            return " Idmessage : " + _IdMessage + " Idtopic : " + _IdTopic + " Iduser : " + _IdUser
                + " Date : " + _DateMessage + " Contenu : " + _ContentMessage;
        }
        #endregion
    }
}