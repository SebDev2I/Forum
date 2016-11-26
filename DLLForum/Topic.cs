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
    /// Les topics du forum
    /// </summary>
    public class Topic
    {
        #region Attributs et propriétés
        private int _IdTopic;
        [DataMember(Order = 1)]
        public int IdTopic
        {
            get { return _IdTopic; }
            set { _IdTopic = value; }
        }

        private int _IdUser;
        [DataMember(Order = 2)]
        public int IdUser
        {
            get { return _IdUser; }
            set { _IdUser = value; }
        }

        private int _IdRubric;
        [DataMember(Order = 3)]
        public int IdRubric
        {
            get { return _IdRubric; }
            set { _IdRubric = value; }
        }


        private DateTime _DateTopic;
        [DataMember(Order = 4)]
        public DateTime DateTopic
        {
            get { return _DateTopic; }
            set { _DateTopic = value; }
        }

        private string _TitleTopic;
        [DataMember(Order = 5)]
        public string TitleTopic
        {
            get { return _TitleTopic; }
            set { _TitleTopic = value; }
        }

        private string _DescTopic;
        [DataMember(Order = 6)]
        public string DescTopic
        {
            get { return _DescTopic; }
            set { _DescTopic = value; }
        }

        #endregion

        #region Constructeurs
        /// <summary>
        /// Constructeur par défaut
        /// </summary>
        public Topic()
        {
            _IdTopic = 0;
            _IdUser = 0;
            _IdRubric = 0;
            _DateTopic = System.DateTime.Now;
            _TitleTopic = "TitreEssai";
            _DescTopic = "DesciptionEssai";
        }

        /// <summary>
        /// Constructeur complet
        /// </summary>
        /// <param name="idtopic"></param>
        /// <param name="iduser"></param>
        /// <param name="idrubric"></param>
        /// <param name="datetopic"></param>
        /// <param name="titletopic"></param>
        /// <param name="desctopic"></param>
        public Topic(int idtopic, int iduser, int idrubric, DateTime datetopic, string titletopic, string desctopic)
        {
            _IdTopic = idtopic;
            _IdUser = iduser;
            _IdRubric = idrubric;
            _DateTopic = datetopic;
            _TitleTopic = titletopic;
            _DescTopic = desctopic;
        }
        #endregion

        #region Méthodes
        /// <summary>
        /// Méthode affichant les messages du topic
        /// </summary>
        public void ShowMessages()
        {

        }
        #endregion

        #region "Méthodes redéfinies"
        public override string ToString()
        {
            return " Id : " + _IdTopic
                + " IdUser = " + _IdUser
                + " IdRubric = " + _IdRubric
                + " Date : " + _DateTopic
                + " Titre : " + _TitleTopic
                + " Description : " + _DescTopic;
        }
        #endregion
    }
}

