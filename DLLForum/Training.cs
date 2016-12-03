using DLLForumV2;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace DLLForum
{
    public class Training : ForumBase
    {
        public TrainingDTO Data { get; set; }
        public Training()
        {
            this.Data = new TrainingDTO();
        }

        public Training(TrainingDTO dto)
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
            if (Data.NameTraining == DTOBase.String_NullValue)
            {
                this.ValidationErrors.Add(new ValidationError("Training.NameTraining", "<NAME_TRAINING> est requis"));
                return false;
            }
            else if (Data.NameTraining.Length > 50)
            {
                this.ValidationErrors.Add(new ValidationError("Training.NameTraining", "<NAME_TRAINING> doit contenir 10 caractères au maximum"));
                return false;
            }
            else return true;
        }
        /*#region Attributs et propriétés
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

        #endregion*/

        #region "Méthodes redéfinies"
        public override string ToString()
        {
            return "Id : " + Data.IdTraining 
                + " Name : " + Data.NameTraining;
        }

        
        #endregion
    }
}
