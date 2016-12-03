using Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DLLForumV2
{
    public class Training : ForumBase
    {
        public int IdTraining { get; set; }
        public string NameTraining { get; set; }
        public TrainingDTO DTO { get; set; }
        public Training()
        {
            IdTraining = Int_NullValue;
            NameTraining = String_NullValue;
            DTO = new TrainingDTO();
        }

        public Training(TrainingDTO dto)
        {
            IdTraining = dto.IdTraining;
            NameTraining = dto.NameTraining;
        }

        public Training(int idtraining, string nametraining)
        {
            IdTraining = idtraining;
            NameTraining = nametraining;
            DTO = new TrainingDTO();
            DTO.IdTraining = idtraining;
            DTO.NameTraining = nametraining;
        }
        public override string ToString()
        {
            return "Id : " + IdTraining 
                + " Name : " + NameTraining;
        }

        public override List<ValidationError> Validate()
        {
            Val_Name();
            return this.ValidationErrors;
        }

        public bool Val_Name()
        {
            if(NameTraining == ForumBase.String_NullValue)
            {
                this.ValidationErrors.Add(new ValidationError("Training.NameTraining", "<NAME_TRAIINIG> est requis"));
                return false;
            }
            else if (NameTraining.Length > 10)
            {
                this.ValidationErrors.Add(new ValidationError("Training.NameTraining", "<NAME_TRAINING> doit contenir 10 caractères au maximum"));
                return false;
            }
            return true;
        }
    }
}
