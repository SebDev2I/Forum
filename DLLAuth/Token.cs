using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace DLLAuth
{
    [DataContract]
    public class Token
    {
        #region Attributs et propriétés
        private int _IdUser;
        [DataMember]
        public int IdUser
        {
            get { return _IdUser; }
            set { _IdUser = value; }
        }

        private long _Time;
        [DataMember]
        public long Time
        {
            get { return _Time; }
            set { _Time = value; }
        }

        private string _TokenSpe;
        [DataMember]
        public string TokenSpe
        {
            get { return _TokenSpe; }
            set { _TokenSpe = value; }
        }

        public bool Valid { get; set; }
        #endregion

        #region Constructeurs
        public Token() { }
        public Token(int iduser, string loginuser, string password, long time)
        {
            _IdUser = iduser;
            _Time = time;
            _TokenSpe = TokenManager.GenerateTokenClient(loginuser, password);
            Valid = false;
        }
        /*public Token(int iduser, string loginuser, long time)
        {
            _IdUser = iduser;
            _Time = time;
            _TokenSpe = TokenManager.GenerateTokenWS(loginuser, password);
        }*/
        #endregion

        #region Méthodes

        #endregion

        #region "Méthodes redéfinies"
        public override string ToString()
        {
            return "token : " + _TokenSpe;
        }
        #endregion
    }
}