using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using ConsumeWSRest;
using DALForum;
using Common;

namespace WSForum
{
    public class ServiceForum : IForum
    {
        public WSR_Result GetEssai(WSR_Param param)
        {
            return new WSR_Result();
        }

        public WSR_Result GetMessages(WSR_Param param)
        {
            RegisteredDb db = new RegisteredDb();
            List<RegisteredDTO> list = db.GetAll();
            WSR_Result r = new WSR_Result(list, true);
            return r;
        }
    }
}
