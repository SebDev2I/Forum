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
        public WSR_Result GetUserById(WSR_Param param, string iduser)
        {
            RegisteredDb db = new RegisteredDb();
            RegisteredDTO registered = db.GetUserById(Convert.ToInt32(iduser));
            WSR_Result r = new WSR_Result(registered, true);
            return r;
        }

        public WSR_Result GetUsers(WSR_Param param)
        {
            RegisteredDb db = new RegisteredDb();
            List<RegisteredDTO> list = db.GetAll();
            WSR_Result r = new WSR_Result(list, true);
            return r;
        }
    }
}
