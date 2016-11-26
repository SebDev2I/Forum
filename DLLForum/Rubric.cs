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
    /// Les rubriques du forum
    /// </summary>
    public class Rubric
    {
        #region Attributs et propriétés
        private int _IdRubric;
        [DataMember(Order = 1)]
        public int IdRubric
        {
            get { return _IdRubric; }
            set { _IdRubric = value; }
        }

        private string _NameRubric;
        [DataMember(Order = 2)]
        public string NameRubric
        {
            get { return _NameRubric; }
            set { _NameRubric = value; }
        }

        #endregion

        #region Constructeurs
        /// <summary>
        /// Constructeur par défaut
        /// </summary>
        public Rubric()
        {
            _IdRubric = 0;
            _NameRubric = "EssaiRubric";
        }

        /// <summary>
        /// Constructeur complet
        /// </summary>
        /// <param name="idrubric"></param>
        /// <param name="namerubric"></param>
        public Rubric(int idrubric, string namerubric)
        {
            _IdRubric = idrubric;
            _NameRubric = namerubric;
        }
        #endregion

        #region Méthodes
        /// <summary>
        /// Méthode affichant les topics par rubrique
        /// </summary>
        public List<Topic> ShowTopics()
        {
            List<Topic> listTopics = new List<Topic>();

            return listTopics;
        }
        #endregion

        #region "Méthodes redéfinies"
        public override string ToString()
        {
            return " Id : " + _IdRubric + " Nom : " + _NameRubric;
        }
        #endregion
    }
}

