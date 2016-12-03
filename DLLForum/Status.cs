using DLLForumV2;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace DLLForum
{
    [DataContract]
    public class Status : ForumBase
    {
        public StatusDTO Data { get; set; }
        public Status()
        {
            this.Data = new StatusDTO();
        }

        public Status(StatusDTO dto)
        {
            this.Data = dto;
        }

        public override List<ValidationError> Validate()
        {
            Val_Name();
            return this.ValidationErrors;
        }

        private bool Val_Name()
        {
            if (Data.NameStatus == DTOBase.String_NullValue)
            {
                this.ValidationErrors.Add(new ValidationError("Status.NameStatus", "<NAME_STATUS> est requis"));
                return false;
            }
            else if (Data.NameStatus.Length > 50)
            {
                this.ValidationErrors.Add(new ValidationError("Status.NameStatus", "<NAME_STATUS> doit contenir 50 caractères au maximum"));
                return false;
            }
            else if (!AuditTool.IsAlpha(Data.NameStatus))
            {
                this.ValidationErrors.Add(new ValidationError("Status.NameStatus", "<NAME_STATUS> ne peut contenir de chiffres"));
                return false;
            }
            else return true;
        }

        /*#region Attributs et propriétés
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

        #endregion*/

        #region "Méthodes redéfinies"
        public override string ToString()
        {
            return "Id : " + Data.IdStatus 
                + " Name : " + Data.NameStatus;
        }
        #endregion
    }
}
