using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DLLForum
{
    public abstract class ForumBase
    {
        public List<ValidationError> ValidationErrors { get; set; }

        public ForumBase()
        {
            ValidationErrors = new List<ValidationError>();
        }
        public abstract List<ValidationError> Validate();
    }
}
