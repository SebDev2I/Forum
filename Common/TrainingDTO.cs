using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common
{
    public class TrainingDTO : DTOBase
    {
        public int IdTraining { get; set; }
        public string NameTraining { get; set; }

        public TrainingDTO()
        {
            IdTraining = Int_NullValue;
            NameTraining = String_NullValue;
            IsNew = true;
        }
    }
}
