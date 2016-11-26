using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace DLLForum
{
    [DataContract]
    public class Status
    {

        #region Attributs et propriétés
        private int _IdStatus;
        [DataMember(Order = 1)]
        public int IdStatus
        {
            get { return _IdStatus; }
            set { _IdStatus = value; }
        }

        private string _NameStatus;
        [DataMember(Order = 2)]
        public string NameStatus
        {
            get { return _NameStatus; }
            set { _NameStatus = value; }
        }

        #endregion

        #region Constructeurs
        public Status()
        {
            _IdStatus = 0;
            _NameStatus = "EssaiStatus";
        }

        public Status(int id, string namestatus)
        {
            _IdStatus = id;
            _NameStatus = namestatus;
        }
        #endregion

        #region Méthodes

        #endregion

        #region "Méthodes redéfinies"
        public override string ToString()
        {
            return " Id : " + _IdStatus + " Name : " + _NameStatus;
        }
        #endregion
    }
}
