using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common
{
    public class RubricDTO : DTOBase
    {
        public int IdRubric { get; set; }
        public string NameRubric { get; set; }

        public RubricDTO()
        {
            IdRubric = Int_NullValue;
            NameRubric = String_NullValue;
            IsNew = true;
        }
    }
}
