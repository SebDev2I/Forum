using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DLLForumV2
{
    public class Training
    {
        public int IdTraining { get; set; }
        public string NameTraining { get; set; }

        public Training()
        {
        }

        public override string ToString()
        {
            return "Id : " + IdTraining 
                + " Name : " + NameTraining;
        }
    }
}
