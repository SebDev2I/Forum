using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DLLForum
{
    /// <summary>
    /// Connait Registered, Rubric et Topic
    /// </summary>
    public class Forum
    {
        #region Attributs et propriétés
        private Registered _Pers;

        public Registered Pers
        {
            get { return _Pers; }
            set { _Pers = value; }
        }

        private Rubric _Rub;

        public Rubric Rub
        {
            get { return _Rub; }
            set { _Rub = value; }
        }

        #endregion

        #region Constructeurs
        /// <summary>
        /// Constructeur par défaut
        /// </summary>
        public Forum() { }

        /// <summary>
        /// Constructeur complet
        /// </summary>
        /// <param name="p"></param>
        /// <param name="r"></param>
        public Forum(Registered person, Rubric rubric)
        {
            _Pers = person;
            _Rub = rubric;
        }
        #endregion

        #region Méthodes
        public void GetRubrics()
        {

        }

        public void GetTopics()
        {

        }

        public void GetMessages()
        {

        }
        #endregion
    }
}