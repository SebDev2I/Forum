using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace DLLForum
{
    [DataContract]
    public class Training
    {
        #region Attributs et propriétés
        private int _IdTraining;
        [DataMember(Order = 1)]
        public int IdTraining
        {
            get { return _IdTraining; }
            set { _IdTraining = value; }
        }

        private string _NameTraining;
        [DataMember(Order = 2)]
        public string NameTraining
        {
            get { return _NameTraining; }
            set { _NameTraining = value; }
        }

        #endregion

        #region Constructeurs
        public Training()
        {
            _IdTraining = 0;
            _NameTraining = "EssaiTraining";
        }

        public Training(int id, string nametraining)
        {
            _IdTraining = id;
            _NameTraining = nametraining;
        }
        #endregion

        #region Méthodes

        #endregion

        #region "Méthodes redéfinies"
        public override string ToString()
        {
            return " Id : " + _IdTraining + " Name : " + _NameTraining;
        }
        #endregion
    }
}
