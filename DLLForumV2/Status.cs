using Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DLLForumV2
{
    public class Status : ForumBase
    {
        public int IdStatus { get; set; }
        public string NameStatus { get; set; }
        public StatusDTO DTO { get; set; }

        public Status()
        {
            IdStatus = Int_NullValue;
            NameStatus = String_NullValue;
            DTO = new StatusDTO();
        }

        public Status(StatusDTO dto)
        {
            IdStatus = dto.IdStatus;
            NameStatus = dto.NameStatus;
        }

        public Status(int idstatus, string namestatus)
        {
            IdStatus = idstatus;
            NameStatus = namestatus;
            DTO = new StatusDTO();
            DTO.IdStatus = idstatus;
            DTO.NameStatus = namestatus;
        }
        public override string ToString()
        {
            return "Id : " + IdStatus
                + " Name : " + NameStatus;
        }

        public override List<ValidationError> Validate()
        {
            Val_Name();
            return this.ValidationErrors;
        }

        private bool Val_Name()
        {
            if (NameStatus == ForumBase.String_NullValue)
            {
                this.ValidationErrors.Add(new ValidationError("Status.NameStatus", "<NAME_STATUS> est requis"));
                return false;
            }
            else if (NameStatus.Length > 10)
            {
                this.ValidationErrors.Add(new ValidationError("Training.NameTraining", "<NAME_STATUS> doit contenir 50 caractères au maximum"));
                return false;
            }
            return true;
        }
    }
}
