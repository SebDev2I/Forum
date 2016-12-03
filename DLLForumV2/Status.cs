using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DLLForumV2
{
    public class Status
    {
        public int IdStatus { get; set; }
        public string NameStatus { get; set; }

        public Status()
        {
        }

        public override string ToString()
        {
            return "Id : " + IdStatus
                + " Name : " + NameStatus;
        }
    }
}
