using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using ConsumeWSRest;

namespace WSForum
{
    public class ServiceForum : IForum
    {
        public WSR_Result GetMessages(WSR_Param param)
        {
            return new WSR_Result();
        }
    }
}
