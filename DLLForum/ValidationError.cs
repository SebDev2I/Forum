using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DLLForum
{
    public class ValidationError
    {
        public string PropertyName { get; set; }
        public string Information { get; set; }
        public List<ValidationError> ValidationErrors { get; set; }
        public ValidationError() { }
        public ValidationError(string propertyname, string information) : this()
        {
            PropertyName = propertyname;
            Information = information;
        }

    }
}
